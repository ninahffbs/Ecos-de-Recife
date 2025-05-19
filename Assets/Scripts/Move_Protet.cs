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
    // Start is called before the first frame update
    

    // Update is called once per frame
    void Update()
    {
        if(isChasing == true)
        {
            Vector2 direcao = (player.position - transform.position).normalized;
            transform.position += (Vector3)direcao * speed * Time.deltaTime;
        }
    }
    private void OnTriggerStay2D(Collider2D collider)
    {
        if(collider.CompareTag("Player"))
        {
            Vector2 PosicaoAtual = this.transform.position;
            Vector2 PosicaoPlayer = collider.transform.position;

            Vector2 direcao = (PosicaoPlayer - PosicaoAtual).normalized;
            int valorX = Mathf.RoundToInt(direcao.x);
            if (valorX > 0)
            {
                this.spriteRenderer.flipX = true;
            }
            else if (valorX < 0)
            {
                this.spriteRenderer.flipX = false;
            }
            this.animator.SetBool("movendo", true);
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
        if(collision.gameObject.tag == "Player")
        {
            for(int i = 0; i < 1; i++)
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
}
