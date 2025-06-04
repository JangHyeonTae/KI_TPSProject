using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InventorySlot : PooledObject
    , IPointerEnterHandler // 하이라이트 시작
    , IPointerExitHandler  // 하이라이트 마칠때
    , IBeginDragHandler
    , IDragHandler         // IDragHandler 시작
    , IEndDragHandler     
{
    
    public Image slotImage;

    private SlotParent slotSideParent;
    private int myIndex;

    private Vector3 startPos;
    private Vector3 dragPos;

    [SerializeField] private Image colorImage;
    Color prevColor;

    public void Init(Item _itemData, SlotParent parent,int _myIndex)
    {
        myIndex = _myIndex;
        itemData = _itemData;
        slotSideParent = parent;
        SetSlot();
    }

    public void Outit()
    {
        myIndex = -1;
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
        startPos = transform.position;
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
            transform.position = startPos;
        }
    }

    private void AddDrag(MySlotParent mySlotParent)
    {
        if (mySlotParent == null) return;

        mySlotParent.AddItem(itemData);
        Manager.InvenInstance.RemoveSideItem(itemData);
        Manager.InvenInstance.SideSlotParent.GetComponent<SlotParent>().RemoveSideItem(itemData);
    }

}
