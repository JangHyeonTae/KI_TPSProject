using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using static UnityEditor.Progress;

public class InventorySlot : PooledObject
    , IPointerEnterHandler // 하이라이트 시작
    , IPointerExitHandler  // 하이라이트 마칠때
    , IBeginDragHandler
    , IDragHandler         // IDragHandler 시작
    , IEndDragHandler     
    // Drag부분이 inventoryCanvasSlot가 아니면 제자리,
// inventoryCanvasSlot일경우 해당 inventoryCanvas 슬롯
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

    //public void Init(int index, SlotParent parent)
    //{
    //    myIndex = index;
    //    slotSideParent = parent;
    //    
    //}

    //private void SetSlot()
    //{
    //    itemData = slotSideParent.GetSideItemAt(myIndex);
    //    if (itemData == null)
    //    {
    //        slotImage.sprite = null;
    //        slotImage.color = new Color(1, 1, 1, 0);
    //        return;
    //    }
    //
    //    slotImage.sprite = itemData.imageSprite;
    //    slotImage.color = Color.white;
    //}
    
    
    //private void SetSideSlot()
    //{
    //    itemData = slotParent.ShowSideInventory();
    //    if (itemData == null) return;
    //    slotImage.sprite = itemData.imageSprite;
    //}


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
        if (dragPos.x > 205 && dragPos.x < 441 && dragPos.y > 13 && dragPos.y < 245 && itemData != null)
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

        //SlotParent slotParent = slotSideParent;

        mySlotParent.AddItem(itemData);
        Manager.InvenInstance.RemoveSideItem(itemData);
        Manager.InvenInstance.SideSlotParent.GetComponent<SlotParent>().RemoveSideItem(itemData);
        Destroy(gameObject);    
    }

}
