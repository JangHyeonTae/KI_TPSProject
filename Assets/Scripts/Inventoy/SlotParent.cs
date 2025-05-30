using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class SlotParent : MonoBehaviour
{
    [SerializeField] private int slotSize;
    public List<InventorySlot> slotList;
    public InventorySlot slot;

    private InventorySlot sideSlot;
    private void Start()
    {
        slotList = new List<InventorySlot>();
    }

    public void AddSideSlot(Item item)
    {
        slotList.Add(slot);
        sideSlot = Instantiate(slot, transform);
        sideSlot.Init(item, this);
    }

    public void RemoveSideSlot(Item item)
    {
        slotList.Remove(slot);
    }

    //public Item GetSideItemAt(int index)
    //{
    //    if (index < 0 || index >= Manager.InvenInstance.sideItemList.Count)
    //        return null;
    //
    //    return Manager.InvenInstance.sideItemList[index];
    //}

    //public void AddSideList()
    //{
    //    int index = Manager.InvenInstance.sideItemList.Count - 1;
    //
    //    InventorySlot inst = Instantiate(slot, transform);
    //    inst.Init(index, this);
    //    slotList.Add(inst);
    //}

    //public Item ShowSideInventory()
    //{
    //    
    //    for (int i = 0; i < Manager.InvenInstance.sideItemList.Count; i++)
    //    {
    //        if (slotList[i] == null) return null;
    //    
    //        slotList[i].itemData = Manager.InvenInstance.sideItemList[i];
    //    }
    //    return slot
    //}



}