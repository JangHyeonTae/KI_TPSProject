using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class SlotParent : MonoBehaviour
{
    [SerializeField] private int slotSize;
    List<InventorySlot> slotList;
    [SerializeField] InventorySlot slot;


    private void Start()
    {
        slotList = new List<InventorySlot>();

        for (int i = 0; i < slotSize; i++)
        {
            InventorySlot inst = Instantiate(slot, gameObject.transform);
            inst.Init(i, this); // 인덱스와 SlotParent 전달
            slotList.Add(inst);
        }
    }

    public Item GetSideItemAt(int index)
    {
        if (index < 0 || index >= Manager.InvenInstance.sideItemList.Count)
            return null;

        return Manager.InvenInstance.sideItemList[index];
    }

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