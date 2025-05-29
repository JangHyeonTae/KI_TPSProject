using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InventoryManager : MonoBehaviour
{
    private static InventoryManager invenInstance;
    public static InventoryManager InvenInstance { get  { return invenInstance; } }

    public UnityEvent OnInventoryOpen;

    public List<Item> itemList = new List<Item>(12);
    public List<Item> sideItemList = new List<Item>(4);

    [SerializeField] private GameObject InventoryCanvas;
    [SerializeField] private int inventoryBagSize;
    [SerializeField] private int inventoryBagCurSize = 0;

   //public int InventoryCurSize { get { return inventoryCurSize; } set { inventoryCurSize = value;  OnChangeSize?.Invoke()} }
   //public UnityEvent OnChangeSize;

    public bool canMove; 
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

    private void OnEnable()
    {
        OnInventoryOpen.AddListener(PopUpInventroy);
        //OnChangeSize.AddListener();
    }

    private void OnDisable()
    {
        OnInventoryOpen.RemoveListener(PopUpInventroy);
    }

    public void AddItem(Item item)
    {
        if (itemList.Count < 12 && inventoryBagCurSize <= inventoryBagSize)
        {
           itemList.Add(item);
        }
        else
        {
            Debug.Log("ÀÎº¥Åä¸®°¡ ²Ë Ã¡½À´Ï´Ù");
            return;
        }
        inventoryBagCurSize += item.size;
    }

    public void AddSideItem(Item item)
    {
        sideItemList.Add(item);
    }

    public void RemoveSideItem()
    {
        sideItemList.Clear();
    }

    public void ShowSideItem(Item item)
    {

    }

    //public void SetGuage()
    //{
    //    GetComponent<UIGuage>().GetUIGuage()
    //}

    private void PopUpInventroy()
    {
        if (InventoryCanvas.activeSelf)
        {
            canMove = true;
            InventoryCanvas.SetActive(false);
        }
        else
        {
            InventoryCanvas.SetActive(true);
            canMove = false;
        }
    }

}
