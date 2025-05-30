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
    }
}
