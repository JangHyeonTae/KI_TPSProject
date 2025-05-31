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
        //����Ͻðڽ��ϱ�? yes/no ���ߵ�
        //Manager.InvenInstance.itemList[??] �ش� ������ ����?? 
        //Ŭ�� �̺�Ʈ : onClick.AddListener?
        
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            Debug.Log("���� ǥ��");
        }
        if (eventData.button == PointerEventData.InputButton.Right)
        {
            Debug.Log("��� ǥ��");
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
