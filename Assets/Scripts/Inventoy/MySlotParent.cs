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
        Manager.InvenInstance.AddItem(item);

        PooledObject obj = slotPool.GetPool();
        MyInventorySlot slotScript = obj.GetComponent<MyInventorySlot>();
        slotList.Add(slotScript);
        slotScript.Init(item, this);
        Debug.Log($"{item.name}");
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
            targetSlot.Outit();
            slotList.Remove(targetSlot);
        }
    }

    //public Item GetSlot(int index)
    //{
    //    //inventoryManager의 list 인덱스에 해당하는 
    //    if (index < 0 || index >= Manager.InvenInstance.itemList.Count) 
    //        return null;
    //
    //    return Manager.InvenInstance.itemList[index];
    //}

}
