using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using static UnityEditor.Progress;

public class DropItem : MonoBehaviour
{
    public static Item draggedItem;
    [SerializeField]public Item item;

    public GameObject prefab;
    [SerializeField] private float peekRange;
    [SerializeField] private LayerMask playerLayer;

    public bool isDrag;
    public UnityEvent<bool> OnDraging;

    

    private bool hasShow = false;
    private void OnEnable()
    {
        prefab = Instantiate(item.dropModel, transform);
        OnDraging.AddListener(Draging);
    }

    private void OnDisable()
    {
        OnDraging.RemoveListener(Draging);
        Destroy(prefab);
        
    }

    private void Update()
    {
        //이벤트로 isDrat == true 일경우 밑의 코드 실행
        if (isDrag)
        {
            Debug.Log($"Destroy : {gameObject.name}, {prefab.name}, {item.name}");
            OnDraging?.Invoke(false);
            //PooledObject의 ReturnObjectPool이 호출되기 전에 Destroy되지 않아야됨
            StartCoroutine(DestroyAfterFrame());
        }
    }

    private IEnumerator DestroyAfterFrame()
    {
        yield return null;
        Destroy(gameObject);
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
