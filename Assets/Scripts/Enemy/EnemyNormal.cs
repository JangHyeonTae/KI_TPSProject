using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyNormal : Enemy, IDamagable
{
    //private bool CanMove = false;

    [SerializeField] private Transform targetTransform;
    [SerializeField] private float targetRange;
    [SerializeField] private LayerMask targetLayer;
    [SerializeField] private float attackRange;
    [SerializeField] Animator animator;
    [SerializeField] private float targetAttackRange;
    public EnemyHpGuage hpBar;
    public Item[] _item;
    public GameObject drop;

    public Vector3 objPos;

    private NavMeshAgent navMeshAgent;

    private void OnEnable()
    {
        SubScribeEvents();
    }

    private void OnDisable()
    {
        UnSubScribeEvents();
    }

    private void Start()
    {
        Hp = MaxHp;
        objPos = transform.position;
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    public void Update()
    {
        EnemyMoveHandler();
    }

    private void EnemyMoveHandler()
    {
        //if (!CanMove) return;

        EnemyMove();
    }

    private void EnemyMove()
    {
        if (targetTransform == null) return;

        if (TargetIn())
        {
            float distance = Vector3.Distance(transform.position, targetTransform.position);
            if (distance <= attackRange)
            {
                navMeshAgent.isStopped = true;
                IsAttack = true;
                IsMoving = false;
            }
            else
            {
                navMeshAgent.isStopped = false;
                IsAttack = false;
                navMeshAgent.SetDestination(targetTransform.position);
                IsMoving = true;
            }
        }
        else
        {
            IsMoving = false;
        }
    }

    public void TakeDamage(float amount)
    {
        Debug.Log(amount);
        if (amount > 1)
        {
            animator.SetTrigger("TakeDamage");
        }
        
        Hp = Mathf.Max(0, Hp - (int)amount);
        if (Hp == 0)
        {
            Die();
        }
    }

    public void Die()
    {
        IsDead = true;
        int rand = Random.Range(0, 3);
        if (rand == 0)
        {
            drop.GetComponent<DropItem>().item = _item[0];
            Instantiate(drop, DeadPos(), Quaternion.identity);
        }
        else if (rand == 1)
        {
            drop.GetComponent<DropItem>().item = _item[1];
            Instantiate(drop, DeadPos(), Quaternion.identity);
        }
        else if (rand == 2)
        {
            drop.GetComponent<DropItem>().item = _item[2];
            Instantiate(drop, DeadPos(), Quaternion.identity);
        }
        else if (rand == 3)
        {
            drop.GetComponent<DropItem>().item = _item[3];
            Instantiate(drop, DeadPos(), Quaternion.identity);
        }
        Destroy(gameObject,1.5f);
    }

    public void EnemyAttack()
    {
        Collider[] _colliders = Physics.OverlapSphere(transform.position, targetAttackRange, targetLayer);

        foreach (Collider target in _colliders)
        {
            Vector3 targetPos = target.transform.position;
            targetPos.y = 0;
            Vector3 attackPos = transform.position;
            attackPos.y = 0;

            Vector3 targetDir = (targetPos - attackPos).normalized;

            if (Vector3.Angle(transform.forward, targetDir) > targetAttackRange * 0.5f)
                continue;


            IDamagable damageable = target.GetComponent<IDamagable>();
            if (damageable != null)
            {
                damageable.TakeDamage(power);
            }

        }
    }


    public bool TargetIn()
    {
        if (Physics.OverlapSphere(transform.position, targetRange, targetLayer).Length > 0)
        {
            return true;
        }
        return false;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, targetRange);
    }

    private void SubScribeEvents()
    {
        OnMoving.AddListener(SetMoveAnim);
        OnAttack.AddListener(SetAttackAnim);
        OnChangeHp.AddListener(SetHpGuage);
        OnDead.AddListener(SetDeadAnim);
    }
    private void UnSubScribeEvents()
    {
        OnMoving.RemoveListener(SetMoveAnim);
        OnAttack.RemoveListener(SetAttackAnim);
        OnChangeHp.RemoveListener(SetHpGuage);
        OnDead.RemoveListener(SetDeadAnim);
    }

    private void SetMoveAnim(bool value) => animator.SetBool("IsMoving", value);
    private void SetAttackAnim(bool value) => animator.SetBool("Attack", value);
    private void SetDeadAnim(bool value) => animator.SetBool("IsDead", value);
    private void SetHpGuage(int value)
    {
        float hp = value / (float)MaxHp;
        hpBar.SetHpFillAmount(hp);
    }

    public Vector3 DeadPos()
    {
        return transform.position;
    }
}
