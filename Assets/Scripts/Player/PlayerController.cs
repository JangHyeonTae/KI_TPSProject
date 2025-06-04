using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEditorInternal.Profiling.Memory.Experimental;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour, IDamagable
{ 
    public bool isCanMove;

    private Animator animator;
    private PlayerStatus status;
    private PlayerMovement movement;
    private PlayerFight playerFight;
    //public Weapon weapon;

    public GameObject bloodParticle;

    public float attackDelay = 1.6f;
    public float delay = 0;
    private bool attacking;

    public Transform groundCheck;
    private float groundDistance = 0.05f;
    public HpGuageUI hpBar;

    public LayerMask groundLayer;
    private void Awake()
    {
        animator = GetComponent<Animator>();
        status = GetComponent<PlayerStatus>();
        movement = GetComponent<PlayerMovement>();
        playerFight = GetComponent<PlayerFight>();
    }

    private void Start()
    {
        if (Manager.InvenInstance != null && Manager.InvenInstance.InventoryCanvas != null)
        {
            Manager.InvenInstance.InventoryCanvas.SetActive(false);
        }
    }
    void Update()
    {
        delay += Time.deltaTime;
        isCanMove = IsAttackAnim();
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (Manager.InvenInstance.canMove)
            {
                if (isCanMove == true)
                {
                    isCanMove = false;
                }
                status.IsAttack = false;
                status.IsMove = false;
                movement.rigid.angularVelocity = Vector3.zero;
                movement.rigid.velocity = Vector3.zero;
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
        movement.isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundLayer);
        HandlePlayerController();
    }

    
    

    public void TakeDamage(float amount)
    {
        Instantiate(bloodParticle, transform.position, Quaternion.identity);
        status.CurHp = Mathf.Max(0, status.CurHp - (int)amount);
        if (status.CurHp == 0)
        {
            PlayerDie();
        }
    }

    private void PlayerDie()
    {
        isCanMove = false;
        animator.SetTrigger("IsDead");
        Destroy(gameObject, 2f);
    }

    public void Heal(int amount)
    {
        status.CurHp = Mathf.Min(status.maxHp, status.CurHp + amount);
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
            Stop();
        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            ActiveSkill1();
            delay = 0;
            Stop();

        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            ActiveSkill2();
            delay = 0;
            Stop();
        }
    }

    private void Stop()
    {
        isCanMove = false;
        movement.rigid.angularVelocity = Vector3.zero;
        movement.rigid.velocity = Vector3.zero;
    }

    public void ActiveSkill1()
    {
        animator.SetTrigger("Skill1");
    }

    public void ActiveSkill2()
    {
        animator.SetTrigger("Skill2");
    }
    
    private void HandleDir()
    {
        if (!isCanMove) return;
        movement.SetRotate();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            movement.Jump(status.jumpForce);
        }
        
        float moveSpeed;
        if (status.IsAttack)// || Manager.InvenInstance.IsFull)
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
        status.OnChangedHp += SetHpGuageUI;
    }

    private void UnSubscribe()
    {
        status.OnMove -= SetMoveAnim;
        status.OnChangedHp -= SetHpGuageUI;
    }

    private void SetMoveAnim(bool value) => animator.SetBool("IsMove",value);
    
    private void SetHpGuageUI(int value)
    {
        float hp = value / (float)status.maxHp;
        hpBar.HPGuageUI(hp);
    }
}
