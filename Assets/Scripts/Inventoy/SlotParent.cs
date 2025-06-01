using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class SlotParent : MonoBehaviour
{
    public InventorySlot slot;
    public List<InventorySlot> slotList;
    private ObjectPool sideSlotPool;
    
    private void Awake()
    {
        sideSlotPool = new ObjectPool(slot,6,transform);
    }
    
    private void Start()
    {
        slotList = new List<InventorySlot>();
    }
    
    public void AddSideItem(Item item)
    {
        PooledObject obj = sideSlotPool.GetPool();
        if (obj == null) return;
        InventorySlot sideSlot = obj.GetComponent<InventorySlot>();
        slotList.Add(sideSlot);
        sideSlot.Init(item, this);
    }
    
    public void RemoveSideItem(Item item)
    {
        
        InventorySlot targetSlot = null;
    
        
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



}