using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BulletController : MonoBehaviour
{
    float BulletTTL = 5;
    [SerializeField]
    GameObject particleToSpawn;
    [SerializeField]
    Transform particleSpawnPoint;

    void Update()
    {
        BulletTTL -= Time.deltaTime;
        if (BulletTTL <= 0)
        {
            Destroy(gameObject);    
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Tank1")
        {
            GameObject.Find("Canvas").GetComponent<ScoreManager>().AddP2Score();
            GameObject.Find("Tank1").GetComponent<HealthManager>().TakeDamage(10); 
        }
        if (collision.gameObject.name == "Tank2")
        {
            GameObject.Find("Canvas").GetComponent<ScoreManager>().AddP1Score();
            GameObject.Find("Tank2").GetComponent<HealthManager>().TakeDamage(10);
        }
        ParticleSpawner();
        Destroy(gameObject);

    }
    public void ParticleSpawner()
    {
        Instantiate(particleToSpawn, particleSpawnPoint.position, particleSpawnPoint.rotation);
    }
}
