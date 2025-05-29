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
    


    public void OnBeginDrag(PointerEventData eventData)
    {
        throw new NotImplementedException();
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
