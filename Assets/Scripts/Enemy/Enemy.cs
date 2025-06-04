using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Enemy : MonoBehaviour, IDamagable
{
    public string name;
    public int power;

    public int MaxHp;

    private int hp;
    public int Hp { get { return hp; } set { hp = value; OnChangeHp?.Invoke(hp); } }
    public UnityEvent<int> OnChangeHp;

    private bool isAttack;
    public bool IsAttack { get { return isAttack; } set { isAttack = value; OnAttack?.Invoke(isAttack); } }
    public UnityEvent<bool> OnAttack;

    private bool isDead;
    public bool IsDead { get { return isDead; } set { isDead = value; OnDead?.Invoke(isDead); } }
    public UnityEvent<bool> OnDead;

    private bool isMoving;
    public bool IsMoving { get { return isMoving; } set { isMoving = value; OnMoving?.Invoke(isMoving); } }
    public UnityEvent<bool> OnMoving;
}
