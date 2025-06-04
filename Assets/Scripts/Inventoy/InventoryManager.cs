using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
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

    public List<Item> itemList = new List<Item>();
    public List<Item> sideItemList = new List<Item>();

    public GameObject InventoryCanvas;
    public GameObject MySlotParent;
    public GameObject SideSlotParent;
    public GameObject MyInventoryPanel;
    public GameObject MyInventoryOutPanel;
    public UIGuage BagGuageUI;



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
    }

    private void OnDisable()
    {
        OnInventoryOpen.RemoveListener(PopUpInventroy);
        OnChangeBagSum.RemoveListener(BagGuage);
    }

    private void Start()
    {
        Sum = 0;
        maxSum = 100;
    }


    public void AddItem(Item item)
    {
        if (itemList.Count < 12)
        {
            int num = 0;
            itemList.Add(item);
            Sum += item.size;
        }
    }

    public void RemoveItem(int num)
    {
        if (itemList == null || itemList.Count == 0) return;
        int index = itemList.FindIndex(item => item.ID == num);

        if (index == -1) return;

        Sum = Mathf.Max(0,Sum - itemList[index].size);
        itemList.RemoveAt(index);
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

    public void BagGuage(int value)
    {
        float bagGuage = value / (float)maxSum;
        BagGuageUI.BagGuageUI(bagGuage);
    }

}
