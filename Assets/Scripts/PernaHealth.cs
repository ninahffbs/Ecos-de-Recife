using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PernaHealth : MonoBehaviour
{
    public int currentHealth;
    public int maxHealth = 20;
    void Start()
    {
        currentHealth = maxHealth;
    }
    public void ChangeHealth(int amount)
    {
        currentHealth += amount;
        if(currentHealth < 0)
        {
            gameObject.SetActive(false);
        }
    }
    void TakeDamage(int amount)
    {
        currentHealth -= amount;

        if(currentHealth <=0 )
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerStay2D(Collider2D collider)
    {
        if (collider.tag != "lama")
        {
            gameObject.transform.parent = collider.gameObject.transform;
            Destroy(gameObject);
            GetComponent<CircleCollider2D>().enabled = false;
        }
    }
    private IEnumerator LoadSceneAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene("Game Over Tela");
    }
}