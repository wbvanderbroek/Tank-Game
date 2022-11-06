using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HealthManager : MonoBehaviour
{
    public int maxHealth = 60;
    public int currentHealth;
    public HealthBar healthBar;

    [SerializeField] GameObject Tank1;
    [SerializeField] GameObject Tank2;
    [SerializeField] GameObject turnEngine;
    [SerializeField] HealthManager healthManager1;
    [SerializeField] HealthManager healthManager2;
    public static bool player1won = false;
    public static bool player2won = false;
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
            if (healthManager1.currentHealth <= 0)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
                player2won = true;
            }
            if (healthManager2.currentHealth <= 0)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
                player1won = true;
            }
            Destroy(gameObject);
        }
    }
}
