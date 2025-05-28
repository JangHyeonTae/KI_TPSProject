using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropItem : MonoBehaviour
{
    [SerializeField] Item item;

    private GameObject prefab;

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
}
