using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
    , IPointerEnterHandler // ���̶���Ʈ ����
    , IPointerExitHandler  // ���̶���Ʈ ��ĥ��
    , IBeginDragHandler
    , IDragHandler         // IDragHandler ����
    , IEndDragHandler     
    // Drag�κ��� inventoryCanvasSlot�� �ƴϸ� ���ڸ�,
// inventoryCanvasSlot�ϰ�� �ش� inventoryCanvas ����
{
    public Image slotImage;
    public Item itemData;

    private SlotParent slotParent;
    private int myIndex;

    private Vector3 starPos;
    private Vector3 dragPos;
    public void Init(int index, SlotParent parent)
    {
        myIndex = index;
        slotParent = parent;
    }

    private void Update()
    {
        SetSlot();
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
            Debug.Log($"{dragPos.x}, {dragPos.y}, {dragPos.z}");
        }
    }
    //Manager.InvenInstance.itemList�ϰ�� Manager.InvenInstance.itemList.AddItem(item)���� �ű�
    //slotParent�� 
    //if()
    public void OnEndDrag(PointerEventData eventData)
    {
        Manager.InvenInstance.MyInventoryPanel.SetActive(false);
        if (dragPos.x > 205 && dragPos.x < 441 && dragPos.y > 13 && dragPos.y < 245)
        {
            Debug.Log("CanMove");
        }
        else
        {
            transform.position = starPos;
        }
    }

}
