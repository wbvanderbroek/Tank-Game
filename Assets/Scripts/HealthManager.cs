using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    public int maxHealth = 60;
    public int currentHealth;
    public HealthBar healthBar;

    [SerializeField] GameObject Tank1;
    [SerializeField] GameObject Tank2;
    [SerializeField] GameObject turnEngine;
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth); 
        if (currentHealth <= 0)
        {
            Tank1.GetComponent<TankController>().enabled = false;
            Tank2.GetComponent<TankController>().enabled = false;
            turnEngine.GetComponent<TurnManager>().enabled = false;

            Destroy(gameObject);
        }
    }
}
