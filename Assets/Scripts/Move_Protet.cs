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
    void Update()
    {
        if (isChasing)
        {
            Vector2 direcao = (player.position - transform.position).normalized;
            transform.position += (Vector3)direcao * speed * Time.deltaTime;

            AtualizarDirecao(player); 
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
        if (collision.gameObject.tag == "Player")
        {
            for (int i = 0; i < 1; i++)
            {
                heart.vida--;
                heart.HealthLogic();
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
        Vector2 direcao = (alvo.position - transform.position).normalized;
        int valorX = Mathf.RoundToInt(direcao.x);

        if (valorX > 0)
            spriteRenderer.flipX = true;
        else if (valorX < 0)
            spriteRenderer.flipX = false;

        animator.SetBool("movendo", true);
    }
}

