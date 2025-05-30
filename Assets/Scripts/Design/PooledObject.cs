using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PooledObject : MonoBehaviour
{
    private ObjectPool objectPool { get; set; }

    public void PooledInit(ObjectPool _objectPool)
    {
        objectPool = _objectPool;
    }

    public void ReturnPool()
    {
        objectPool.AddPool(this);
    }

}
