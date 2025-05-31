using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MyInventorySlot : PooledObject, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    public Image slotImage;
    public string itemName = null;
    MySlotParent parent;

    [SerializeField] private Image colorImage;
    Color prevColor;

    private int myIndex;
    public void Init(Item _item, MySlotParent _parent)
    {
        itemData = _item;
        parent = _parent;
        itemName = _item.name;
        SetSlot();
    }

    public void Outit()
    {
        itemData = null;
    }

    private void SetSlot()
    {
        //if (parent != null)
        //    itemData = parent.GetSlot(myIndex);

        if (itemData == null)
        {
            slotImage.sprite = null;
            slotImage.color = new Color(1, 1, 1, 0);
            return;
        }

        slotImage.sprite = itemData.imageSprite;
        slotImage.color = Color.white;
    }





    public void OnPointerClick(PointerEventData eventData)
    {
        //사용하시겠습니까? yes/no 떠야됨
        //Manager.InvenInstance.itemList[??] 해당 아이템 삭제?? 
        //클릭 이벤트 : onClick.AddListener?
        
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            Debug.Log("정보 표시");
        }
        if (eventData.button == PointerEventData.InputButton.Right)
        {
            Debug.Log("사용 표시");
        }
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

}
