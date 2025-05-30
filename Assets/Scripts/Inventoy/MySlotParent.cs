using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MySlotParent : MonoBehaviour
{
    [SerializeField] private MyInventorySlot slot;
    private ObjectPool slotPool;

    private void Awake()
    {
        slotPool = new ObjectPool(slot, 12, transform);
    }

    public void AddItem(Item item)
    {
        Manager.InvenInstance.AddItem(item);
        //slotPool.GetPool();
        //아이템 정보를 더해지는 인벤토리에 저장되야함
        //Manager.InvenInstance.AddItem(item);

        PooledObject obj = slotPool.GetPool();
        MyInventorySlot slotScript = obj.GetComponent<MyInventorySlot>();
        int index = Manager.InvenInstance.itemList.Count - 1;
        slotScript.Init(index, this);
        Debug.Log($"{item.name}");
    }

    public Item GetSlot(int index)
    {
        //inventoryManager의 list 인덱스에 해당하는 
        if (index < 0 || index >= Manager.InvenInstance.itemList.Count) 
            return null;

        return Manager.InvenInstance.itemList[index];
    }

}
