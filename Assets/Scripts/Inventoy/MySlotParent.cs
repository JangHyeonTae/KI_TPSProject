using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class MySlotParent : MonoBehaviour
{
    [SerializeField] private MyInventorySlot slot;
    private ObjectPool slotPool;

    public List<MyInventorySlot> slotList;

    private void Awake()
    {
        slotPool = new ObjectPool(slot, 12, transform);
    }

    private void Start()
    {
        slotList = new List<MyInventorySlot>();
    }

    public void AddItem(Item item)
    {
        int index = 0;
        Manager.InvenInstance.AddItem(item);

        PooledObject obj = slotPool.GetPool();
        MyInventorySlot slotScript = obj.GetComponent<MyInventorySlot>();
        slotList.Add(slotScript);

        while (slotList.Exists(slot => slot.itemData != null && slot.itemData.ID == index))
        {
            index++;
        }
        item.ID = index;
        slotScript.Init(item, this,index);

    }

    public void RemoveItem(Item item)
    {
        MyInventorySlot targetSlot = null;

        for (int i = 0; i < slotList.Count; i++)
        {
            if (slotList[i] != null && slotList[i].itemData == item)
            {
                targetSlot = slotList[i];
                break;
            }
        }

        if (targetSlot != null)
        {
            targetSlot.ReturnObjectPool();
            slotList.Remove(targetSlot);
            Manager.InvenInstance.RemoveItem(targetSlot.itemData.ID);
            targetSlot.Outit();
        }

    }

}
