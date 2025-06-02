using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalEnemy : Enemy, IDamagable
{

    public Item[] _item;
    public GameObject drop;

    public Vector3 objPos;
    private void Start()
    {
        Hp = MaxHp;
        objPos = transform.position;
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
        int rand = UnityEngine.Random.Range(0, _item.Length);
        GameObject dropObj = Instantiate(drop, transform.position, Quaternion.identity);

        DropItem dropItem = dropObj.GetComponent<DropItem>();
        if (dropItem != null)
        {
            dropItem.item = _item[rand];
        }
        else
        {
            Debug.Log($"null : {dropItem.item}");
        }
        Destroy(gameObject);
    }

    public void EnemyAttack(float amount)
    {
        Debug.Log($"Enemy Attack : {amount}");
    }
}
