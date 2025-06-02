using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, IDamagable
{
    public string name;
    public int power;
    public EnemySkill[] skill;

    public int MaxHp;

    private int hp;
    public int Hp { get { return hp; } set { hp = value; OnChangeHp?.Invoke(hp); } }
    public event Action<int> OnChangeHp;

    private bool isAttack;
    public bool IsAttack { get { return isAttack; } set { isAttack = value; OnAttack?.Invoke(isAttack); } }
    public event Action<bool> OnAttack;

    private bool isTakeDamage;
    public bool IsTakeDamage { get { return isTakeDamage; } set { isTakeDamage = value;  OnTakeDamage?.Invoke(isTakeDamage); } }
    public event Action<bool> OnTakeDamage;

}
