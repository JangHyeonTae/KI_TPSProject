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
//, IDragHandler         // IDragHandler ����
//, IEndDragHandler
//, IDropHandler         // Drag�κ��� inventoryCanvasSlot�� �ƴϸ� ���ڸ�,
// inventoryCanvasSlot�ϰ�� �ش� inventoryCanvas ����
{
    public Image slotImage;
    public Item itemData;

    private SlotParent slotParent;

    private void Awake()
    {
        slotParent = GetComponentInParent<SlotParent>();
    }

    private void Update()
    {
        SetSlot();
    }
    private void SetSlot()
    {
        itemData = slotParent.ShowSideInventory();
        if (itemData == null) return;
        slotImage.sprite = itemData.imageSprite;
    }


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
    
    

}
