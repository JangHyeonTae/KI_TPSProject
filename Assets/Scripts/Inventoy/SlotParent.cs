using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using UnityEngine.UI;

public class SlotParent : MonoBehaviour
{
    [SerializeField] private int slotSize;
    List<InventorySlot> slotList;
    [SerializeField] InventorySlot slot; 


    void Start()
    {
        slotList = new List<InventorySlot>();

        for (int i = 0; i < slotSize; i++)
        {
            InventorySlot inst = Instantiate(slot,gameObject.transform);
            slotList.Add(inst);
        }
    }

    public Item ShowSideInventory()
    {
        for (int i = 0; i < Manager.InvenInstance.sideItemList.Count; i++)
        {
            if (slotList[i] == null) return null;
    
            return slotList[i].itemData = Manager.InvenInstance.sideItemList[i];
        }
        return null;
    }
}
