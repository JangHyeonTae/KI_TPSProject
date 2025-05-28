using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour, IDamagable
{
    public bool isCanMove { get => attacking; }
    private Animator animator;
    private PlayerStatus status;
    private PlayerMovement movement;
    [SerializeField] AnimatorOverrideController weaponOverride = null;

    public Transform rightWeaponSpawn;
    public Transform leftWeaponSpawn;
    public Weapon weapon;

    private GameObject instWeapon;

    private float delay = 0;
    private bool attacking;
    private void Awake()
    {
        animator = GetComponent<Animator>();
        status = GetComponent<PlayerStatus>();
        movement = GetComponent<PlayerMovement>();
    }

    private void Start()
    {
        if (weapon.isRight)
            SpawnWeapon();

        //else if(!weapon.isRight && weapon.canDouble)
        //    instWeapon = Instantiate(weapon.model, leftWeaponSpawn);
    }

    private void OnEnable()
    {
        Subscribe();
    }

    private void OnDisable()
    {
        UnSubscribe();
    }

    private void Update()
    {
        delay += Time.deltaTime;

        if (delay > weapon.attackDelay)
            attacking = true;
        else
            attacking = false;

        if (Input.GetMouseButtonDown(0))
        {
            animator.SetTrigger("NormalAttack");
            delay = 0;
        }
    }

    private void FixedUpdate()
    {
        HandlePlayerController();
    }
    
    public void SpawnWeapon()
    {
        instWeapon = Instantiate(weapon.model, rightWeaponSpawn);
        animator.runtimeAnimatorController = weaponOverride;
    }

    public void Attack()
    {
        
    }
    public void TakeDmage()
    {

    }

    private void HandlePlayerController()
    {
        if (!isCanMove) return;
        HandleDir();
    }

    private void HandleDir()
    {
        movement.SetRotate();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            movement.Jump(status.jumpForce);
        }
        
        float moveSpeed;
        if (status.IsAttack)
        {
            moveSpeed = status.downSpeed;
        }
        else if (Input.GetKey(KeyCode.LeftShift))
        {
            moveSpeed = status.runSpeed;
        }
        else
        {
            moveSpeed = status.walkSpeed;
        }

        Vector3 moveDir = movement.HandlerPlayerMove(moveSpeed);
        if (moveDir != Vector3.zero)
        {
            status.IsMove = true;
        }
        else
        {
            status.IsMove = false;
        }
        Vector3 avatorRot = moveDir;
        movement.SetAvatarRotation(avatorRot);

        Vector3 input = movement.InputDir();
        animator.SetFloat("X", input.x * moveSpeed);
        animator.SetFloat("Y", input.z * moveSpeed);
    }

    private void Subscribe()
    {
        status.OnMove += SetMoveAnim;
    }

    private void UnSubscribe()
    {
        status.OnMove -= SetMoveAnim;
    }

    private void SetMoveAnim(bool value) => animator.SetBool("IsMove",value);
}
