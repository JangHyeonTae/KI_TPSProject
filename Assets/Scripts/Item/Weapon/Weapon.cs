using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : Item
{
    public AnimatorOverrideController weaponOverride;
    //public AnimatorOverrideController movementOverride;

    public int value;
    public bool canDouble;
    public bool isRight;
    public float attackDelay;

}
