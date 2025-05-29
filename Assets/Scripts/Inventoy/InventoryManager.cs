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

    public List<Item> itemList = new List<Item>();
    [SerializeField] private GameObject InventoryCanvas;

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
    }

    private void OnDisable()
    {
        OnInventoryOpen.RemoveListener(PopUpInventroy);
    }

    public void AddItem(Item item)
    {
        itemList.Add(item);
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


}
