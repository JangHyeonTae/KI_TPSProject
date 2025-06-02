using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFight : MonoBehaviour
{
    private PlayerStatus status;
    public Transform rightWeaponSpawn;
    public Transform leftWeaponSpawn;
    [SerializeField] private Weapon weapon = null;
    private Weapon currentWeapon;

    GameObject target;
    public LayerMask targetLayer;
    private GameObject instWeapon;

    private void Start()
    {
        status = GetComponent<PlayerStatus>();
        SpawnWeapon(weapon);
    }

    //호출시 해당 무기 장착
    public void SpawnWeapon(Weapon _weapon)
    {
        Transform handTransform;
        currentWeapon = _weapon;

        if (currentWeapon == null) return;
        Animator animator = GetComponent<Animator>();

        if (_weapon.WeaponTransform())
            handTransform = rightWeaponSpawn;
        else
            handTransform = leftWeaponSpawn;

        currentWeapon.Spawn(handTransform,animator);
    }

    //public void Attack()
    //{
    //    IDamagable target = SetTarget();
    //    if (target == null) return;
    //    target.TakeDamage(currentWeapon.GetDamage() * status.curPower);
    //}
    public void Attack()
    {
        Collider[] _colliders = Physics.OverlapSphere(transform.position, currentWeapon.GetRange(), targetLayer);
    
        foreach (Collider target in _colliders)
        {
            Vector3 targetPos = target.transform.position;
            targetPos.y = 0;
            Vector3 attackPos = transform.position;
            attackPos.y = 0;
    
            Vector3 targetDir = (targetPos - attackPos).normalized;
    
            if (Vector3.Angle(transform.forward, targetDir) > currentWeapon.GetRange() * 0.5f)
                continue;

            
            IDamagable damageable = target.GetComponent<IDamagable>();
            if (damageable != null)
            {
                damageable.TakeDamage(currentWeapon.GetDamage() * status.curPower);
            }
    
        }
    }
    public void Skill1Attack()
    {
        Collider[] _colliders = Physics.OverlapSphere(transform.position, currentWeapon.GetSkill1Range(), targetLayer);

        foreach (Collider target in _colliders)
        {
            Vector3 targetPos = target.transform.position;
            targetPos.y = 0;
            Vector3 attackPos = transform.position;
            attackPos.y = 0;

            Vector3 targetDir = (targetPos - attackPos).normalized;

            if (Vector3.Angle(transform.forward, targetDir) > currentWeapon.GetSkill1Range() * 0.5f)
                continue;


            IDamagable damageable = target.GetComponent<IDamagable>();
            if (damageable != null)
            {
                damageable.TakeDamage(currentWeapon.GetDamage() * status.curPower * currentWeapon.skill1.damage);
            }

        }
        
    }
    public void Skill2Attack()
    {
        Collider[] _colliders = Physics.OverlapSphere(transform.position, currentWeapon.GetSkill2Range(), targetLayer);

        foreach (Collider target in _colliders)
        {
            Vector3 targetPos = target.transform.position;
            targetPos.y = 0;
            Vector3 attackPos = transform.position;
            attackPos.y = 0;

            Vector3 targetDir = (targetPos - attackPos).normalized;

            if (Vector3.Angle(transform.forward, targetDir) > currentWeapon.GetSkill2Range() * 0.5f)
                continue;


            IDamagable damageable = target.GetComponent<IDamagable>();
            if (damageable != null)
            {
                damageable.TakeDamage(currentWeapon.GetDamage() * status.curPower * currentWeapon.skill2.damage);
            }

        }
        
    }

    private IDamagable SetTarget()
    {
        if(target == null) return null;
        return target.GetComponent<IDamagable>();
    }

    private void Defence()
    {
        PlayerController player = GetComponent<PlayerController>();
        if (player.IsAttackAnim())
        {
            player.TakeDmage(0);
        }
    }

    
}
