using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    private static WeaponManager weaponInstance;
    public static WeaponManager WeaponInstance { get { return weaponInstance; } }

    

    private void Awake()
    {
        if (weaponInstance == null)
        {
            weaponInstance = this;
            Instantiate(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
