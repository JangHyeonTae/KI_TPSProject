using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropItem : MonoBehaviour
{
    [SerializeField] Item item;
    InventoryManager inventory;

    private GameObject prefab;

    private void Awake()
    {
        prefab = GetComponent<GameObject>();
        inventory = FindObjectOfType<InventoryManager>();
    }

    private void OnEnable()
    {
        prefab = Instantiate(item.dropModel, transform);
    }

    private void OnDisable()
    {
        Destroy(prefab);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 7)
        {
            //inventory.itemList.Add(item);
            other.GetComponent<PlayerFight>().SpawnWeapon(DropWeapon());
            Destroy(gameObject);
        }
    }

    private Weapon DropWeapon()
    {
        return item as Weapon;
    }
}
