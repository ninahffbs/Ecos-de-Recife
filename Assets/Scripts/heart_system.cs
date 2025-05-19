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
    PLayer_Controller playerAnimator;
    public Image[] coracao;
    public Sprite cheio;
    public Sprite vazio;
    // Start is called before the first frame update
    void Start()
    {
        playerAnimator = GetComponent<PLayer_Controller>();
    }
    // Update is called once per frame
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
        if(vida <= 0 )
        {
            isDead = true;

            playerAnimator.playerAnimator.SetBool("isDead", isDead);
            GetComponent<PLayer_Controller>().enabled = false;
            Destroy(gameObject, 2f);
            StartCoroutine(LoadSceneAfterDelay(1.5f));
        }
    }
    void OnDestroy()
    {
        playerAnimator.playerAnimator.SetBool("isDead", isDead);
        GetComponent<PLayer_Controller>().enabled = false;
        
    }
    private IEnumerator LoadSceneAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene("Game Over Tela");
    }
}
