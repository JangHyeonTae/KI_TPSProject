using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using static UnityEngine.Rendering.DebugUI;

public class InventoryManager : MonoBehaviour
{
    private static InventoryManager invenInstance;
    public static InventoryManager InvenInstance { get  { return invenInstance; } }

    public int maxSum = 100;
    private int sum;
    public int Sum { get { return sum; } set { sum = value; OnChangeBagSum?.Invoke(sum); } }
    public UnityEvent<int> OnChangeBagSum;

    public UnityEvent OnInventoryOpen;

    public List<Item> itemList;
    public List<Item> sideItemList;

    [SerializeField] private GameObject InventoryCanvas;
    public GameObject MySlotParent;
    public GameObject SideSlotParent;
    public GameObject MyInventoryPanel;
    public UIGuage BagGuageUI;


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
        OnChangeBagSum.AddListener(BagGuage);
        //OnDraging.AddListener(DrapOpen);
    }

    private void OnDisable()
    {
        OnInventoryOpen.RemoveListener(PopUpInventroy);
        OnChangeBagSum.RemoveListener(BagGuage);
        //OnDraging.RemoveListener(DrapOpen);
    }

    private void Start()
    {
        itemList = new List<Item>();
        sideItemList = new List<Item>();

        Sum = 0;
        maxSum = 100;

    }

    public void AddItem(Item item)
    {
        if (itemList.Count < 12 && sum < maxSum)// && inventoryBagCurSize <= inventoryBagSize)
        {
           itemList.Add(item);
            Sum += item.size;
        }
        else
        {
            Debug.Log("�κ��丮�� �� á���ϴ�");
            return;
        }
    }


    public void AddSideItem(Item item)
    {
        sideItemList.Add(item);
    }

    public void RemoveAllSideItem()
    {
        sideItemList.Clear();
    }

    public void RemoveSideItem(Item item)
    {
        if (item == null) return;
        sideItemList.Remove(item);
    }

    //public void AddShowItem(Item item)
    //{
    //    slotParent.
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

    //private void DrapOpen(bool value) => MyInventoryPanel.SetActive(value);

    public void BagGuage(int value)
    {
        Debug.Log($"BagGuageUI : {value}");
        float bagGuage = value / (float)maxSum;
        BagGuageUI.BagGuageUI(bagGuage);
    }
}
