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
//, IDragHandler         // IDragHandler 시작
//, IEndDragHandler
//, IDropHandler         // Drag부분이 inventoryCanvasSlot가 아니면 제자리,
// inventoryCanvasSlot일경우 해당 inventoryCanvas 슬롯
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
