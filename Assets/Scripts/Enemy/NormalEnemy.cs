using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalEnemy : Enemy, IDamagable
{

    public Item[] _item;
    public GameObject drop;

    Vector3 objPos;
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
        int rand = UnityEngine.Random.Range(0, 3);
        if (rand == 0)
        {
            drop.GetComponent<DropItem>().item = _item[0];
            Instantiate(drop,objPos,Quaternion.identity);
        }
        else if (rand == 1)
        {
            drop.GetComponent<DropItem>().item = _item[1];
            Instantiate(drop, objPos, Quaternion.identity);
        }
        else if (rand == 2)
        {
            drop.GetComponent<DropItem>().item = _item[2];
            Instantiate(drop, objPos, Quaternion.identity);
        }
        else if (rand == 3)
        {
            drop.GetComponent<DropItem>().item = _item[3];
            Instantiate(drop, objPos, Quaternion.identity);
        }
        Destroy(gameObject);
    }

    public void EnemyAttack(float amount)
    {
        Debug.Log($"Enemy Attack : {amount}");
    }
}
