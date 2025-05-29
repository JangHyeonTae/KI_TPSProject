using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

public class DropItem : MonoBehaviour
{
    [SerializeField] Item item;

    public GameObject prefab;
    [SerializeField] private float peekRange;
    [SerializeField] private LayerMask playerLayer;

    private bool hasShow = false;
    private void Awake()
    {
        prefab = GetComponent<GameObject>();
    }

    private void Start()
    {
        
    }
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
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == 7)
        {
            if (hasShow)
            {
                Manager.InvenInstance.RemoveSideItem();
                hasShow = false;
            }
        }
    }


    //private void Range()
    //{
    //    if(Physics.OverlapSphere(transform.position, peekRange, playerLayer).Length > 0)
    //    {
    //        
    //    }
    //    else
    //    {
    //        
    //    }
    //}

    //private void OnDrawGizmos()
    //{
    //    Gizmos.color = Color.red;
    //    Gizmos.DrawWireSphere(transform.position, peekRange);
    //}

    private Weapon DropWeapon()
    {
        return item as Weapon;
    }
}
