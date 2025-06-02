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

    public GameObject weaponParticle;

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

    public float GetSkill1Range()
    {
        return skill1.skillRange;
    }

    public float GetSkill2Range()
    {
        return skill2.skillRange;
    }

    public GameObject ParticleAttack()
    {
        return weaponParticle;
    }

    public GameObject ParticleSkill1()
    {
        return skill1.skillParticle;
    }

    public GameObject ParticleSkill2()
    {
        return skill2.skillParticle;
    }

}
