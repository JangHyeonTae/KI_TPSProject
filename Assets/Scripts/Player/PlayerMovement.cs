using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Transform avatar;

    [SerializeField] private float minPitch;
    [SerializeField] private float maxPitch;
    [SerializeField] private float mouseSensitivity;

    public Rigidbody rigid;
    private PlayerStatus status;


    Vector2 rotateMouse;
    private void Awake()
    {
        rigid = GetComponent<Rigidbody>();
        status = GetComponent<PlayerStatus>();
    }

    private void Start()
    {
        status.CurHp = status.maxHp;
    }

    public void SetAvatarRotation(Vector3 direction)
    {
        if (direction == Vector3.zero) return;

        Quaternion targetRotation = Quaternion.LookRotation(direction);
        avatar.rotation = Quaternion.Lerp(avatar.rotation, targetRotation, status.rotSpeed * Time.deltaTime);
    }

    public Vector3 HandlerPlayerMove(float moveSpeed)
    {
        Vector3 movedir = MoveDir();

        Vector3 vel = rigid.velocity;
        vel.x = movedir.x * moveSpeed;
        vel.z = movedir.z * moveSpeed;

        rigid.velocity = vel;

        return movedir;
    }

    private Vector3 MoveDir()
    {
        Vector3 dir = InputDir();

        Vector3 direction = transform.right * dir.x + transform.forward * dir.z;

        return direction.normalized;
    }

    public Vector3 InputDir()
    {
        float dirX, dirZ;

        dirX = Input.GetAxis("Horizontal");
        dirZ = Input.GetAxis("Vertical");

        Vector3 dir = new Vector3(dirX, 0, dirZ);

        return dir;
    }

    public void Jump(float force)
    {
        rigid.AddForce(Vector3.up * force,ForceMode.Impulse);
    }

    public void SetRotate()
    {
        Vector2 mouse;
        mouse.x = Input.GetAxis("Mouse X") * mouseSensitivity;
        mouse.y = -Input.GetAxis("Mouse Y") * mouseSensitivity;

        rotateMouse.x += mouse.x;
        rotateMouse.y = Mathf.Clamp(rotateMouse.y + mouse.y, minPitch, maxPitch);

        transform.rotation = Quaternion.Euler(0, rotateMouse.x, 0);

    }
}
