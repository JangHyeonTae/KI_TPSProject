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

    private void Update()
    {
        Range();
    }


    private void Range()
    {
        if(Physics.OverlapSphere(transform.position, peekRange, playerLayer).Length > 0)
        {
            if (!hasShow)
            {
                Manager.InvenInstance.AddSideItem(item);
                Debug.Log("11");
                hasShow = true;
            }
        }
        else
        {
             Manager.InvenInstance.RemoveSideItem();
            hasShow = false;
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
