using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool
{
    private List<PooledObject> poolList;
    private PooledObject targetPrefab;
    private Transform poolParent;

    public ObjectPool(PooledObject _targetPrefab, int _initSize, Transform _parent = null)
    {
        Init(_targetPrefab, _initSize, _parent);
    }

    private void Init(PooledObject _targetPrefab, int _initSize, Transform _parent = null)
    {
        poolList = new List<PooledObject>();
        poolParent = _parent;
        targetPrefab = _targetPrefab;
        for (int i = 0; i < _initSize; i++)
        {
            CreatePool();
        }
    }
        
    public PooledObject GetPool()
    {
        if (poolList.Count == 0) return null;

        PooledObject obj = poolList[poolList.Count-1];
        poolList.RemoveAt(poolList.Count - 1);
        obj.gameObject.SetActive(true);

        return obj;
    }

    public void AddPool(PooledObject inst)
    {
        inst.transform.parent = poolParent.transform;
        inst.gameObject.SetActive(false);
        poolList.Add(inst);
    }

    public void CreatePool()
    {
        PooledObject inst = MonoBehaviour.Instantiate(targetPrefab);
        targetPrefab.PooledInit(this);
        AddPool(inst);
    }
}
