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
        slotPool.GetPool();
    }

}
