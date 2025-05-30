using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using static UnityEditor.Progress;

public class InventorySlot : MonoBehaviour
    , IPointerEnterHandler // 하이라이트 시작
    , IPointerExitHandler  // 하이라이트 마칠때
    , IBeginDragHandler
    , IDragHandler         // IDragHandler 시작
    , IEndDragHandler     
    // Drag부분이 inventoryCanvasSlot가 아니면 제자리,
// inventoryCanvasSlot일경우 해당 inventoryCanvas 슬롯
{
    
    public Image slotImage;
    public Item itemData = null;

    private SlotParent slotSideParent;
    private int myIndex;

    private Vector3 starPos;
    private Vector3 dragPos;

    //[SerializeField] DropItem dropItem;
    
    
    
    //private void OnEnable()
    //{
    //    OnDraging.AddListener(dropItem.DestroyObject);
    //}
    //
    //private void OnDisable()
    //{
    //    OnDraging.RemoveListener(dropItem.DestroyObject);
    //}

    public void Init(int index, SlotParent parent)
    {
        myIndex = index;
        slotSideParent = parent;
    }

    private void Update()
    {
        SetSlot();
    }

    private void SetSlot()
    {
        itemData = slotSideParent.GetSideItemAt(myIndex);
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


    public void OnPointerEnter(PointerEventData eventData)
    {
        slotImage.color = Color.yellow;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        slotImage.color = Color.white;
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
    //Manager.InvenInstance.itemList일경우 Manager.InvenInstance.itemList.AddItem(item)으로 옮김
    //slotParent의 
    //if()
    public void OnEndDrag(PointerEventData eventData)
    {
        DropItem dropItem = FindObjectOfType<DropItem>() ;
        
        Manager.InvenInstance.MyInventoryPanel.SetActive(false);
        if (dragPos.x > 205 && dragPos.x < 441 && dragPos.y > 13 && dragPos.y < 245 && itemData != null)
        {
            if (dropItem != null)
            {
                dropItem.isDrag = true;
            }
            AddDrag(Manager.InvenInstance.MySlotParent.GetComponent<MySlotParent>());
        }
        else
        {
            transform.position = starPos;
            if (dropItem != null)
            {
                dropItem.isDrag = false;
            }
        }
    }

    private void AddDrag(MySlotParent mySlotParent)
    {
        if (itemData == null) return;
        Debug.Log("AddTry");
        slotSideParent.AddSideList();
        mySlotParent.AddItem(itemData);
        Manager.InvenInstance.RemoveSideItem(myIndex);
        //mySlotParent.
        gameObject.SetActive(false);    
    }

}
