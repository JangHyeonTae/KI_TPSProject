using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerStatus : MonoBehaviour
{
    [SerializeField] public float jumpForce;

    [SerializeField]
    [Range(0, 10)] public float downSpeed;

    [SerializeField]
    [Range(0,10)] public float walkSpeed;

    [SerializeField]
    [Range(0, 10)] public float runSpeed;

    [SerializeField]
    public float rotSpeed;

    [SerializeField]
    public int curPower;

    public int maxHp;

    private int curHp;
    public int CurHp { get { return curHp; } set { curHp = value; OnChangedHp?.Invoke(curHp); } }
    public event Action<int> OnChangedHp;

    private bool isAttack;
    public bool IsAttack { get { return isAttack; } set { isAttack = value;  OnAttack?.Invoke(isAttack); } }
    public event Action<bool> OnAttack;

    private bool isMove;
    public bool IsMove { get { return isMove; } set { isMove = value; OnMove?.Invoke(isMove); } }
    public event Action<bool> OnMove;

    private bool isTakeDamage;
    public bool IsTakeDamage { get { return isTakeDamage; } set { isTakeDamage = value; OnTakeDamage?.Invoke(isTakeDamage); } }
    public event Action<bool> OnTakeDamage;

    //private bool isDead;
    //public bool IsDead { get { return isDead; } set { isDead = value; OnDead?.Invoke(isDead); } }
    //public event Action<bool> OnDead;
}
