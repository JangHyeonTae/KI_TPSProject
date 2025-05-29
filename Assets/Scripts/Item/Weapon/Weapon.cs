using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : Item
{
    [SerializeField] AnimatorOverrideController weaponOverride = null;

    public int value;
    public float range;
    public bool canDouble;
    public bool isRight;
    public float attackDelay;

    private const string weaponName = "Weapon";

    public void Spawn(Transform handTransform, Animator animator)
    {
        DestroyOldWeapon(handTransform);
        if (model != null)
        {
            GameObject weapon = Instantiate(model, handTransform);
            weapon.name = weaponName;
        }
        animator.runtimeAnimatorController = weaponOverride;
    }

    public void DestroyOldWeapon(Transform handTrans)
    {
        Transform oldWeapon = handTrans.Find(weaponName);
        if (oldWeapon == null) return;

        oldWeapon.name = "DestroyWeapon";
        Destroy(oldWeapon.gameObject);
    }

    public bool WeaponTransform()
    {
        return isRight;
    }

    public float GetDamage()
    {
        return value;
    }

    public float GetRange()
    {
        return range;
    }

}
