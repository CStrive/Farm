using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private CharacterController controller;
    private Animator animator;

    public float moveSpeed = 1.4f;

    [Header("Movement System")]
    public float walkSpeed = 1.4f;
    public float runSpeed = 2f;

    PlayerInteractor playerInteractor;

    private void Start()
    {
        controller= GetComponent<CharacterController>();    
        animator = GetComponent<Animator>();

        playerInteractor = GetComponentInChildren<PlayerInteractor>();
    }

    private void Update()
    {
        Move();
        Interact();

    }

    public void Interact()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            playerInteractor.Interact();
        }
    }

    public void Move()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        Vector3 dir = new Vector3(horizontal,0f,vertical).normalized;
        Vector3 velocity = moveSpeed * Time.deltaTime * dir;

        //ÊÇ·ñ³å´Ì
        if (Input.GetButton("Sprint"))
        {
            moveSpeed = runSpeed;
            animator.SetBool("Running", true);
        } else
        {
            moveSpeed = walkSpeed;
            animator.SetBool("Running", false);
        }

        if (dir.magnitude >= 0.1)
        {
            transform.rotation = Quaternion.LookRotation(dir);
            controller.Move(velocity);
        } 
        animator.SetFloat("Speed",velocity.magnitude);

    }

}
