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
        if (poolList.Count == 0)  CreatePool();

        //아이템 제거 후 다시 감지할 때
        while (poolList.Count > 0)
        {
            PooledObject obj = poolList[poolList.Count - 1];
            poolList.RemoveAt(poolList.Count - 1);

            if (obj == null || obj.gameObject == null)
            {
                Debug.Log("제거된 오브젝트 감지, 스킵");
                continue;
            }

            obj.gameObject.SetActive(true);

            return obj;
        }
        return null;
    }

    public void AddPool(PooledObject inst)
    {
        if (inst == null || inst.gameObject == null)
        {
            return;
        }

        inst.transform.parent = poolParent.transform;
        inst.gameObject.SetActive(false);
        poolList.Add(inst);
    }

    public void CreatePool()
    {
        PooledObject inst = MonoBehaviour.Instantiate(targetPrefab);
        inst.PooledInit(this);
        AddPool(inst);
    }
}
