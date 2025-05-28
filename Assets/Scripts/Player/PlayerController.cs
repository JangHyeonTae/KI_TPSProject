using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public bool isCanMove { get; set; } = true;
    private Animator animator;
    private PlayerStatus status;
    private PlayerMovement movement;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        status = GetComponent<PlayerStatus>();
        movement = GetComponent<PlayerMovement>();
    }

    private void FixedUpdate()
    {
        HandlePlayerController();
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
        Vector3 avatorRot = moveDir;
        movement.SetAvatarRotation(avatorRot);

        Vector3 input = movement.InputDir();
        animator.SetFloat("X", input.x * moveSpeed);
        animator.SetFloat("Z", input.z * moveSpeed);
    }
}
