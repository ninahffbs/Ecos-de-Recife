using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float walkSpeed = 5f; 
    public float sprintSpeed = 8f; 
    public Rigidbody2D rb;
    public Animator animator;
    private Vector2 movement;
    private float currentMoveSpeed;

    void Start()
    {
        currentMoveSpeed = walkSpeed;
    }

    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        movement.Normalize(); 
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            animator.SetTrigger("Attack");
        }
        
        if (Input.GetKey(KeyCode.LeftShift))
        {
            currentMoveSpeed = sprintSpeed;
            animator.SetFloat("AnimationSpeedMultiplier", 1.5f); // Example: 1.5x normal speed
        }
        
        else
        {
            currentMoveSpeed = walkSpeed;
            animator.SetFloat("AnimationSpeedMultiplier", 1.0f);
        }

        float speed = movement.sqrMagnitude; 
        if (speed < 0.01f)
            speed = 0f;

        animator.SetFloat("Speed", speed); 

        if (movement.x > 0)
            transform.localScale = new Vector3(3, 3, 3); 
        else if (movement.x < 0)
            transform.localScale = new Vector3(-3, 3, 3);
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * currentMoveSpeed * Time.fixedDeltaTime);
    }
}