using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PooledObject : MonoBehaviour
{

    public Item itemData = null;
    private ObjectPool objectPool { get; set; }

    public void PooledInit(ObjectPool _objectPool)
    {
        objectPool = _objectPool;
    }

    public void ReturnObjectPool()
    {
        objectPool.AddPool(this);
    }

}
