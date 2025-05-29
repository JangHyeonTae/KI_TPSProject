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

    private void Attack()
    {
        IDamagable target = SetTarget();
        if (target == null) return;
        target.TakeDamage(currentWeapon.GetDamage() * status.curPower);
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
