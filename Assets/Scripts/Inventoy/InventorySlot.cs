using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using static UnityEditor.Progress;

public class InventorySlot : PooledObject
    , IPointerEnterHandler // ���̶���Ʈ ����
    , IPointerExitHandler  // ���̶���Ʈ ��ĥ��
    , IBeginDragHandler
    , IDragHandler         // IDragHandler ����
    , IEndDragHandler     
{
    
    public Image slotImage;

    private SlotParent slotSideParent;
    private int myIndex;

    private Vector3 starPos;
    private Vector3 dragPos;


    [SerializeField] private Image colorImage;
    Color prevColor;

    public void Init(Item _itemData, SlotParent parent)
    {
        itemData = _itemData;
        slotSideParent = parent;
        SetSlot();
    }

    public void Outit()
    {
        itemData = null;
    }

    private void SetSlot()
    {

        if (itemData == null)
        {
            slotImage.sprite = null;
            slotImage.color = new Color(1, 1, 1, 0);
            return;
        }

        slotImage.sprite = itemData.imageSprite;
        slotImage.color = Color.white;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        prevColor = colorImage.color;
        colorImage.color = Color.yellow;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        colorImage.color = prevColor;
    }



    public void OnBeginDrag(PointerEventData eventData)
    {
        starPos = transform.position;
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            Manager.InvenInstance.MyInventoryPanel.SetActive(true);
            transform.position += (Vector3)eventData.delta;
            dragPos = transform.position;
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Manager.InvenInstance.MyInventoryPanel.SetActive(false);
        if (dragPos.x < 1875 && dragPos.x > 900 && dragPos.y > 100 && dragPos.y < 1003 && itemData != null)// && !Manager.InvenInstance.IsFull)
        {

            DropItem.draggedItem = itemData;
            DropItem[] allDropItems = FindObjectsOfType<DropItem>();

            foreach (DropItem drop in allDropItems)
            {
                if (drop.item == itemData)
                {
                    drop.OnDraging?.Invoke(true);
                    break;
                }
            }
            AddDrag(Manager.InvenInstance.MySlotParent.GetComponent<MySlotParent>());
        }
        else
        {
            transform.position = starPos;
        }
    }

    private void AddDrag(MySlotParent mySlotParent)
    {
        if (itemData == null) return;

        
        mySlotParent.AddItem(itemData);
        Manager.InvenInstance.RemoveSideItem(itemData);
        Manager.InvenInstance.SideSlotParent.GetComponent<SlotParent>().RemoveSideItem(itemData);
        
        
    }

}
