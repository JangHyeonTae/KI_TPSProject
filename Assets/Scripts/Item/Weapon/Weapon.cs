using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : Item
{
    [SerializeField] AnimatorOverrideController weaponOverride = null;
    //public AnimatorOverrideController movementOverride;

    public int value;
    public bool canDouble;
    public bool isRight;
    public float attackDelay;

    public void Spawn(Transform handTransform, Animator animator)
    {
        Instantiate(model, handTransform);
        animator.runtimeAnimatorController = weaponOverride;
    }


}
