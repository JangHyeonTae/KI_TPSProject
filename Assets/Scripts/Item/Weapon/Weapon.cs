using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : Item
{
    public int value;
    public bool canDouble;

    public void Attack(IDamagable target) { }
}
