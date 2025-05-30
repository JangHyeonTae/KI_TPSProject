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
        //����Ͻðڽ��ϱ�? yes/no ���ߵ�
        //Manager.InvenInstance.itemList[??] �ش� ������ ����?? 
        //Ŭ�� �̺�Ʈ : onClick.AddListener?
        Debug.Log("����");
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
