using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEditorInternal.Profiling.Memory.Experimental;
using UnityEngine;
using UnityEngine.UI;

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

    public HpGuageUI hpBar; 
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
        //if (Input.GetKeyDown(KeyCode.Alpha1))
        //{
        //    TakeDmage(10);
        //}

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
    
    

    public void TakeDmage(int amount)
    {
        status.CurHp = Mathf.Max(0, status.CurHp - amount);
        Debug.Log($"Damage : {status.CurHp}");
        if (status.CurHp == 0) Debug.Log("³¡");
    }

    public void Heal(int amount)
    {
        Debug.Log($"Heal : {status.CurHp}");
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
        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            ActiveSkill1();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            ActiveSkill2();
        }
    }

    public void ActiveSkill1()
    {
        animator.SetTrigger("Skill1");
    }

    public void ActiveSkill2()
    {
        animator.SetTrigger("Skill2");
    }

    //private IEnumerator CoolTime()
    //{
    //    float tick = 1f / skill.cool;
    //    float t = 0;
    //
    //    imgCool.fillAmount = 1;
    //
    //    while (imgCool.fillAmount > 0)
    //    {
    //        imgCool.fillAmount = Mathf.Lerp(1, 0, t);
    //        t += (Time.deltaTime * tick);
    //
    //        yield return null;
    //    }
    //}

    private void HandleDir()
    {
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
