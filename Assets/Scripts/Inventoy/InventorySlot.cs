using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
    , IPointerEnterHandler // 하이라이트 시작
    , IPointerExitHandler  // 하이라이트 마칠때
    , IBeginDragHandler
    , IDragHandler         // IDragHandler 시작
    , IEndDragHandler
    , IDropHandler         // Drag부분이 inventoryCanvasSlot가 아니면 제자리,
// inventoryCanvasSlot일경우 해당 inventoryCanvas 슬롯
{
    public Image slotImage;
    public Item itemData;

    private SlotParent slotParent;
    private int myIndex;

    private Transform prevTransform;
    public void Init(int index, SlotParent parent)
    {
        myIndex = index;
        slotParent = parent;
    }

    private void Update()
    {
        if (slotParent.name == "SideInventroyContents")
        {
            SetSlot();
        }
    }

    private void SetSlot()
    {
        itemData = slotParent.GetSideItemAt(myIndex);
        if (itemData == null)
        {
            slotImage.sprite = null;
            slotImage.color = new Color(1, 1, 1, 0);
            return;
        }

        slotImage.sprite = itemData.imageSprite;
        slotImage.color = Color.white;
    }
    
    
    //private void SetSideSlot()
    //{
    //    itemData = slotParent.ShowSideInventory();
    //    if (itemData == null) return;
    //    slotImage.sprite = itemData.imageSprite;
    //}


    public void OnBeginDrag(PointerEventData eventData)
    {
        
    }



    public void OnPointerEnter(PointerEventData eventData)
    {
        slotImage.color = Color.yellow;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        slotImage.color = Color.white;
    }

    public void OnDrag(PointerEventData eventData)
    {
        prevTransform.position = transform.position;
        transform.position = eventData.position;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        throw new NotImplementedException();
    }

    public void OnDrop(PointerEventData eventData)
    {
        //Manager.InvenInstance.itemList일경우 Manager.InvenInstance.itemList.AddItem(item)으로 옮김
        //slotParent의 
        //if()
    }
}
