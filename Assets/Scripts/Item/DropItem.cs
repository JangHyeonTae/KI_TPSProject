using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

public class DropItem : MonoBehaviour
{
    [SerializeField] Item item;

    private GameObject prefab;
    [SerializeField] private float peekRange;
    [SerializeField] private LayerMask playerLayer;

    private void Awake()
    {
        prefab = GetComponent<GameObject>();
    }

    private void OnEnable()
    {
        prefab = Instantiate(item.dropModel, transform);
    }

    private void OnDisable()
    {
        Destroy(prefab);
    }

    private void Update()
    {
        Range();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 7)
        {
            //other.GetComponent<PlayerFight>().SpawnWeapon(DropWeapon());
            //Manager.InvenInstance.AddItem(item);
            //Destroy(gameObject);
            
        }
        else
        {
            
        }
    }

    private void Range()
    {
        if (Physics.OverlapSphere(transform.position, peekRange, playerLayer).Length > 0)
        {
            if (Manager.InvenInstance.sideItemList.Contains(item)) return;
            Manager.InvenInstance.AddSideItem(item);
        }
        else
        {
            Manager.InvenInstance.RemoveSideItem();
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, peekRange);
    }

    private Weapon DropWeapon()
    {
        return item as Weapon;
    }
}
