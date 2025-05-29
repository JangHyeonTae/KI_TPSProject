using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal.Profiling.Memory.Experimental;
using UnityEngine;

public class PlayerController : MonoBehaviour, IDamagable
{ 
    public bool isCanMove = true;

    private Animator animator;
    private PlayerStatus status;
    private PlayerMovement movement;
    private PlayerFight playerFight;
    //public Weapon weapon;

    public float attackDelay = 1.6f;
    public float delay = 0;
    private bool attacking;
    private void Awake()
    {
        animator = GetComponent<Animator>();
        status = GetComponent<PlayerStatus>();
        movement = GetComponent<PlayerMovement>();
        playerFight = GetComponent<PlayerFight>();
    }

    private void Start()
    {
        //else if(!weapon.isRight && weapon.canDouble)
        //    instWeapon = Instantiate(weapon.model, leftWeaponSpawn);
    }
    void Update()
    {
        delay += Time.deltaTime;


        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (Manager.InvenInstance.canMove)
            {
                isCanMove = false;
            }
            else
            {
                isCanMove = true;
            }
            Manager.InvenInstance.OnInventoryOpen?.Invoke();
        }
    }
    private void OnEnable()
    {
        Subscribe();
    }

    private void OnDisable()
    {
        UnSubscribe();
    }

    private void FixedUpdate()
    {
        HandlePlayerController();
    }
    
    

    public void TakeDmage(float amount)
    {

    }
    
    public bool IsAttackAnim()
    {
        if (delay > attackDelay)
             attacking = true;
        else
            attacking = false;

        return attacking;
    }

    private void HandlePlayerController()
    {
        if (!isCanMove) return;
        HandleDir();

        if (Input.GetMouseButtonDown(0))
        {
            animator.SetTrigger("NormalAttack");
            delay = 0;
        }
    }

    private void GetItem()
    {
        
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
        if (moveDir != Vector3.zero && IsAttackAnim())
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
