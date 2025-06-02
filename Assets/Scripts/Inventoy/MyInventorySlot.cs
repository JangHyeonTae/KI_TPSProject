using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MyInventorySlot : PooledObject
    , IPointerClickHandler
    , IPointerEnterHandler
    , IPointerExitHandler
    , IBeginDragHandler
    , IDragHandler
    , IEndDragHandler
{
    public Image slotImage;
    public string itemName = null;
    MySlotParent parent;
    public int index;
    [SerializeField] private Image colorImage;
    Color prevColor;

    Vector3 startPos;
    Vector3 dragPos;

    public void Init(Item _item, MySlotParent _parent, int _index)
    {
        index = _index;
        itemData = _item;
        parent = _parent;
        itemName = _item.name;
        SetSlot();
    }

    public void Outit()
    {
        index = 0;
        itemData = null;
    }

    private void SetSlot()
    {
        if (itemData == null)
        {
            slotImage.sprite = null;
            slotImage.color = new Color(1, 1, 1, 0);
            return;
        }

        slotImage.sprite = itemData.imageSprite;
        slotImage.color = Color.white;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        startPos = transform.position;
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            Manager.InvenInstance.MyInventoryOutPanel.SetActive(true);
            transform.position += (Vector3)eventData.delta;
            dragPos = transform.position;
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Manager.InvenInstance.MyInventoryOutPanel.SetActive(false);
        if (dragPos.x > 1850 || dragPos.x < 850 || dragPos.y > 1000 || dragPos.y < 100 && itemData != null)
        {
            AddDrag(Manager.InvenInstance.MySlotParent.GetComponent<MySlotParent>());
        }
        else
        {
            transform.position = startPos;
        }
    }

    private void AddDrag(MySlotParent parent)
    {
        if (parent == null) return;

        parent.RemoveItem(itemData);
    }



    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Right)
        {
            Debug.Log("정보 표시");
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
