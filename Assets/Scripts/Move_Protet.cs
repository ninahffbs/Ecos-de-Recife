using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.XR; 

public class Move_Protet : MonoBehaviour
{
    public Transform player;
    private float input_y; 
    public float speed;
    private bool isChasing = false;
    [SerializeField]
    public new Rigidbody2D rb;

    [SerializeField]
    private SpriteRenderer spriteRenderer;

    [SerializeField]
    private Animator animator;

    public heart_system heart;

    public int damageAmount = 1;

    void Update()
    {
        if (isChasing)
        {
            // Calculate direction and move
            Vector2 direcao = (player.position - transform.position).normalized;
            transform.position += (Vector3)direcao * speed * Time.deltaTime;

            AtualizarDirecao(player); // updates flip and animation
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Player"))
        {
            AtualizarDirecao(collider.transform);
            isChasing = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.CompareTag("Player"))
        {
            PararMovimentacao();
            isChasing = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) 
        {
            PlayerHealth playerHealth = collision.gameObject.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(damageAmount);
            }

            this.animator.SetBool("movendo", false);
            PararMovimentacao();
        }
    }

    private void PararMovimentacao()
    {
        this.rb.velocity = Vector2.zero;
        this.animator.SetBool("movendo", false);
    }

    private void AtualizarDirecao(Transform alvo)
    {
        if (alvo == null) return;

        Vector2 direcao = (alvo.position - transform.position).normalized;
        int valorX = Mathf.RoundToInt(direcao.x);

        if (valorX > 0)
            spriteRenderer.flipX = true; 
        else if (valorX < 0)
            spriteRenderer.flipX = false; 
            
        animator.SetBool("movendo", true);
    }
}