using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Progress;

public class Weapon : Item
{
    [SerializeField] AnimatorOverrideController weaponOverride = null;
    //public string name;
    //public int size;
    //public Sprite imageSprite;
    //public Image icon;
    //[TextArea] public string description;
    //public GameObject model;
    //public GameObject dropModel;

    public int value;
    public float range;
    public bool isRight;
    public float attackDelay;
    public Skill skill1;
    public Skill skill2;    

    private const string weaponName = "Weapon";

    //public Weapon(AnimatorOverrideController weaponOverride, int value, float range, bool isRight, float attackDelay)
    //{
    //    this.weaponOverride = weaponOverride;
    //    this.value = value;
    //    this.range = range;
    //    this.isRight = isRight;
    //    this.attackDelay = attackDelay;
    //}

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
