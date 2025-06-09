using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int currentHealth;
    public int maxHealth = 3;

    public heart_system heartSystem;

    void Awake()
    {
        if (heartSystem == null)
        {
            heartSystem = GetComponent<heart_system>();
            if (heartSystem == null)
            {
                Debug.LogError("PlayerHealth: heart_system component not found on this GameObject or assigned in Inspector!");
            }
        }
    }

    void Start()
    {
        if (currentHealth == 0 || currentHealth > maxHealth) 
        {
            currentHealth = maxHealth;
        }
        if (heartSystem != null)
        {
            heartSystem.vida = currentHealth;
            heartSystem.vidaMax = maxHealth; 
            heartSystem.HealthLogic();
        }
    }

    public void ChangeHealth(int amount)
    {
        currentHealth += amount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth); 
        if (heartSystem != null)
        {
            heartSystem.vida = currentHealth;
            heartSystem.HealthLogic(); 
        }

        Debug.LogError(currentHealth);
    }

    public void TakeDamage(int amount)
    {
        ChangeHealth(-amount); 
    }
}