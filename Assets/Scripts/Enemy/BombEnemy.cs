using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombEnemy : Enemy, IDamagable
{
    public LayerMask targetLayer;

    public float attackRange;
    public Transform targetTransform;

    public GameObject bombParticle;
    private void Start()
    {
        Hp = MaxHp;
    }

    public void TakeDamage(float amount)
    {
        Debug.Log(amount);
        Hp = Mathf.Max(0, Hp - (int)amount);
        if (Hp == 0)
        {
            Die();
        }
    }

    public void Die()
    {
        EnemyAttack(power);
        Destroy(gameObject,1);
    }

    public void EnemyAttack(float amount)
    {
        IDamagable target = SetTarget();
        if (target == null) return;

        GameObject obj = Instantiate(bombParticle,transform.position + Vector3.up * 1.5f,Quaternion.identity);
        target.TakeDamage(amount);
        if (obj != null)
        {
            Destroy(obj);
        }
    }

    public IDamagable SetTarget()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, attackRange, targetLayer);

        foreach (Collider target in colliders)
        {
            IDamagable setTarget = target.GetComponent<IDamagable>();

            return setTarget;
        }

        return null;
    }


}
