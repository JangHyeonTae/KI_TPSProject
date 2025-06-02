using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, IDamagable
{
    public string name;
    //public Weapon weapon;
     

    public void TakeDamage(float amount)
    {
        Debug.Log(amount);
    }

}
