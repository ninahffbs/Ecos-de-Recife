using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Rigidbody2D rb;
    public Animator animator;
    private Vector2 movement;

    void Update()
{
    // Entrada do jogador
    movement.x = Input.GetAxisRaw("Horizontal");
    movement.y = Input.GetAxisRaw("Vertical");
    
    if(Input.GetKeyDown(KeyCode.Space)){
        animator.SetTrigger("Attack");
    }
    // Corrige pequenos valores para 0
    float speed = movement.sqrMagnitude;
    if (speed < 0.01f)
        speed = 0f;

    // Parâmetros de animação
    animator.SetFloat("Speed", speed);

    // Flip do personagem
    if (movement.x > 0)
        transform.localScale = new Vector3(3, 3, 3); // direita
    else if (movement.x < 0)
        transform.localScale = new Vector3(-3, 3, 3); // esquerda
}


    void FixedUpdate()
    {
        // Movimento do personagem
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}
