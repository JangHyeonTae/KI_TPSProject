using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MyInventorySlot : PooledObject
{
    public Image slotImage;
    public Item itemData;

    MySlotParent parent;

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
}
