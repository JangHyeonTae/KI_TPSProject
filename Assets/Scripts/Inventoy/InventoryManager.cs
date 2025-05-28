using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    private static InventoryManager invenInstance;
    public static InventoryManager InvenInstance { get  { return invenInstance; } }

    public List<Item> itemList = new List<Item>();

    public GameObject InventoryCanvas;
    private void Awake()
    {
        if (invenInstance == null)
        {
            invenInstance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void AddItem(Item item)
    {
        itemList.Add(item);
    }

}
