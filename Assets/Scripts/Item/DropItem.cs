using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using static UnityEditor.Progress;

public class DropItem : MonoBehaviour
{
    public static Item draggedItem;

    public GameObject prefab;
    [SerializeField] private float peekRange;
    [SerializeField] private LayerMask playerLayer;

    public bool isDrag;
    public UnityEvent<bool> OnDraging;

    public string name;

    private bool hasShow = false;
    public Item item;

    private void Start()
    {
        Init();
    }

    private void Init()
    {
        name = gameObject.name;
    }

    private void OnEnable()
    {
        if(item != null)
            prefab = Instantiate(item.dropModel, transform);

        OnDraging.AddListener(Draging);
    }

    private void OnDisable()
    {
        OnDraging.RemoveListener(Draging);

        if(item != null)
            Destroy(prefab);
        
    }

    private void Update()
    {
        //�̺�Ʈ�� isDrat == true �ϰ�� ���� �ڵ� ����
        if (isDrag)
        {
            Debug.Log($"Destroy : {gameObject.name}, {prefab.name}, {item.name}");
            OnDraging?.Invoke(false);
            //PooledObject�� ReturnObjectPool�� ȣ��Ǳ� ���� Destroy���� �ʾƾߵ�
            StartCoroutine(DestroyAfterFrame());
        }
    }

    private IEnumerator DestroyAfterFrame()
    {
        GameObject target = GameObject.Find(name);
        yield return null;

        if(target != null)
            Destroy(target);
    }


    public void Draging(bool value) => isDrag = value;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 7)
        {
            if (!hasShow)
            {
                Manager.InvenInstance.AddSideItem(item);
                Manager.InvenInstance.SideSlotParent.GetComponent<SlotParent>().AddSideItem(item);
                hasShow = true;
            }

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == 7)
        {
            if (hasShow)
            {
                Manager.InvenInstance.RemoveSideItem(item);
                Manager.InvenInstance.SideSlotParent.GetComponent<SlotParent>().RemoveSideItem(item);
                Debug.Log($"Drop : {item.name}");
                hasShow = false;
            }
        }
    }

    private Weapon DropWeapon()
    {
        return item as Weapon;
    }


}
