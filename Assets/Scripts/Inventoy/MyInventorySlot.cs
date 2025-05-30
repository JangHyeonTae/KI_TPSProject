using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MyInventorySlot : PooledObject, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    public Image slotImage;
    public Item itemData;

    MySlotParent parent;

    [SerializeField] private Image colorImage;
    Color prevColor;

    private int myIndex;
    public void Init(int index, MySlotParent _parent)
    {
        myIndex = index;
        parent = _parent;
        SetSlot();
    }
    private void SetSlot()
    {
        if (parent != null)
            itemData = parent.GetSlot(myIndex);

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
        Debug.Log("누름");
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
