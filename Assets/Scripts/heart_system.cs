using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class heart_system : MonoBehaviour
{
    public bool isDead;
    public int vida;
    public int vidaMax;
    public PlayerHealth playerHealth;

    PLayer_Controller playerAnimator;

    public Image[] coracao;
    public Sprite cheio;
    public Sprite vazio;

    void Awake()
    {
        if (playerHealth == null)
        {
            playerHealth = GetComponent<PlayerHealth>();
            if (playerHealth == null)
            {
                Debug.LogError("HeartSystem: PlayerHealth component not found on this GameObject or assigned in Inspector!");
            }
        }
        isDead = false;
    }

    void Start()
    {
        playerAnimator = GetComponent<PLayer_Controller>();
        if (playerHealth != null)
        {
            vida = playerHealth.currentHealth;
            vidaMax = playerHealth.maxHealth;
        }
        HealthLogic();
    }

    void Update()
    {
        HealthLogic();
        DeadState();
    }

    public void HealthLogic()
    {
        if(vida > vidaMax)
        {
            vida = vidaMax;
        }

        for (int i = 0; i < coracao.Length; i++)
        {
            if(i < vida)
            {
                coracao[i].sprite = cheio;
            }else
            {
                coracao[i].sprite = vazio;
            }

            if(i < vidaMax)
            {
                coracao[i].enabled = true;
            }else
            {
                coracao[i].enabled = false;
            }
        }
    }

    void DeadState()
    {
        if(vida <= 0 && !isDead)
        {
            isDead = true; 
            Debug.Log("Player has died. Initiating Game Over sequence.");

            if (playerAnimator != null && playerAnimator.playerAnimator != null)
            {
                playerAnimator.playerAnimator.SetBool("isDead", true);
            }

            if (GetComponent<PLayer_Controller>() != null)
            {
                GetComponent<PLayer_Controller>().enabled = false;
            }
            StartCoroutine(LoadSceneAfterDelay(1.5f));
        }
    }

    void OnDestroy()
    {
        Debug.Log("Player GameObject OnDestroy called.");
        if (playerAnimator != null && playerAnimator.playerAnimator != null)
        {
             playerAnimator.playerAnimator.SetBool("isDead", true);
        }
        if (GetComponent<PLayer_Controller>() != null)
        {
            GetComponent<PLayer_Controller>().enabled = false;
        }
    }

    private IEnumerator LoadSceneAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene("Game Over Tela");
    }
}