using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFight : MonoBehaviour
{
    
    public Transform rightWeaponSpawn;
    public Transform leftWeaponSpawn;
    [SerializeField] private Weapon weapon;
    

    private GameObject instWeapon;

    private void Start()
    {
        SpawnWeapon();
    }

    public void SpawnWeapon()
    {
        Transform handTransform;

        if (weapon == null) return;
        Animator animator = GetComponent<Animator>();

        if (weapon.isRight)
            handTransform = rightWeaponSpawn;
        else
            handTransform = leftWeaponSpawn;

        weapon.Spawn(handTransform,animator);
    }
}
