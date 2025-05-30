using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using static UnityEditor.Progress;

public class DropItem : MonoBehaviour
{
    [SerializeField] Item item;

    public GameObject prefab;
    [SerializeField] private float peekRange;
    [SerializeField] private LayerMask playerLayer;

    public bool isDrag;
    

    private bool hasShow = false;
    private void OnEnable()
    {
        prefab = Instantiate(item.dropModel, transform);
    }

    private void OnDisable()
    {
        Destroy(prefab);
    }


    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.layer == 7)
        {
            if (!hasShow)
            {
                Manager.InvenInstance.AddSideItem(item);
                Debug.Log("Add Side Item");
                hasShow = true;
            }

            if (isDrag)
            {
                //InventorySlot dragSlot = other.GetComponent<InventorySlot>();
                //if (dragSlot != null)
                //    Destroy(dragSlot.gameObject);
                //Manager.InvenInstance.RemoveSideItem();

                Destroy(gameObject);
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == 7)
        {
            if (hasShow)
            {
                Manager.InvenInstance.RemoveAllSideItem();
                hasShow = false;
            }
        }
    }
    private Weapon DropWeapon()
    {
        return item as Weapon;
    }


}
