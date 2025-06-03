using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeHealth : MonoBehaviour, IDamagable
{
    public GameObject mazeParticle;
    public int hp;

    private void Start()
    {
        hp = Random.Range(1, 3) * 1000;
    }
    public void TakeDamage(float amount)
    {
        hp = Mathf.Max(0, hp - (int)amount);
        if (hp ==0)
        {
            Instantiate(mazeParticle);
            Destroy(gameObject,0.5f);
        }
    }
}
