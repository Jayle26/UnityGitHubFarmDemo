using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //运动组件
    private CharacterController controller;
    private Animator animator;

    private float moveSpeed = 4f;

    [Header("Movement System")]
    public float walkSpeed = 4f;
    public float runSpeed = 8f;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    public void Move()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        Vector3 dir = new Vector3(horizontal, 0f, vertical).normalized;
        Vector3 velocity = moveSpeed * Time.deltaTime * dir;

        if (Input.GetButton("Sprint"))
        {
            moveSpeed = runSpeed;
            animator.SetBool("Running", true);
        }
        else
        {
            moveSpeed = walkSpeed;
            animator.SetBool("Running", false);
        }

        if (dir.magnitude >= 0.1f)
        {
            transform.rotation = Quaternion.LookRotation(dir);
            animator.SetFloat("Speed", moveSpeed);
            controller.Move(velocity);
        }
        else
        {
            animator.SetFloat("Speed", 0); // 停止移动时设为0，触发Idle
        }
    }
}
