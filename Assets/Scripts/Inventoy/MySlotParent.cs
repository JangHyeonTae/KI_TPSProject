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
        //������ ������ �������� �κ��丮�� ����Ǿ���
        //Manager.InvenInstance.AddItem(item);

        PooledObject obj = slotPool.GetPool();
        MyInventorySlot slotScript = obj.GetComponent<MyInventorySlot>();
        int index = Manager.InvenInstance.itemList.Count - 1;
        slotScript.Init(index, this);
        Debug.Log($"{item.name}");
    }

    public Item GetSlot(int index)
    {
        //inventoryManager�� list �ε����� �ش��ϴ� 
        if (index < 0 || index >= Manager.InvenInstance.itemList.Count) 
            return null;

        return Manager.InvenInstance.itemList[index];
    }

}
