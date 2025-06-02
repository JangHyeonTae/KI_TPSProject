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
    private GameObject instWeapon;

    private void Start()
    {
        status = GetComponent<PlayerStatus>();
        SpawnWeapon(weapon);
    }

    //ȣ��� �ش� ���� ����
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

    private void Attack()
    {
        IDamagable target = SetTarget();
        if (target == null) return;
        target.TakeDamage(currentWeapon.GetDamage() * status.curPower);
    }

    private void Skill1Attack()
    {
        IDamagable target = SetTarget();
        if (target == null) return;
        target.TakeDamage(currentWeapon.GetDamage() * status.curPower * currentWeapon.skill1.damage);
    }

    private void Skill2Attack()
    {
        IDamagable target = SetTarget();
        if (target == null) return;
        target.TakeDamage(currentWeapon.GetDamage() * status.curPower * currentWeapon.skill2.damage);
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
