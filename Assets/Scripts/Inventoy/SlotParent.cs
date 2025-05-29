using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using UnityEngine.UI;

public class SlotParent : MonoBehaviour
{
    [SerializeField] private int slotSize = 12;
    List<InventorySlot> slots;
    [SerializeField] Image slot; 


    void Start()
    {
        slots = new List<InventorySlot>();

        for (int i = 0; i < slotSize; i++)
        {
            Instantiate(slot,gameObject.transform);
        }
    }

    void Update()
    {
        ShowSideInventory();
    }

    private void ShowSideInventory()
    {
        Item[] item = new Item[slotSize];
        for (int i = 0; i < Manager.InvenInstance.sideItemList.Count; i++)
        {
            item[i] = Manager.InvenInstance.sideItemList[i];
            if (item[i] != null)
            {
                slots[i].slotImage = item[i].icon;
            }
            else
            {
                continue;
            }
        }
    }
}
