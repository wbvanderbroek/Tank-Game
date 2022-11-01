using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BulletController : MonoBehaviour
{
    float BulletTTL = 5;
    [SerializeField] GameObject particleToSpawn;
    [SerializeField] Transform particleSpawnPoint;
    private TankController controller1;
    private TankController controller2;

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
        controller1 = GameObject.Find("Tank1").GetComponent<TankController>();
        controller2 = GameObject.Find("Tank2").GetComponent<TankController>();
        if (collision.gameObject.name == "Tank1")
        {
            ParticleSpawner();
            GameObject.Find("Tank1").GetComponent<HealthManager>().TakeDamage(10); 
        }
        if (collision.gameObject.name == "Tank2")
        {
            ParticleSpawner();
            GameObject.Find("Tank2").GetComponent<HealthManager>().TakeDamage(10);
        }

        if (controller1.isPlayerTurn == true)
        {
            GameObject.Find("Main Camera").GetComponent<CameraController>().movingToPlayer1 = true;
        }
        if (controller2.isPlayerTurn == true)
        {
            GameObject.Find("Main Camera").GetComponent<CameraController>().movingToPlayer2 = true;
        }
        Destroy(gameObject);
    }
    private void ParticleSpawner()
    {
        Instantiate(particleToSpawn, particleSpawnPoint.position, particleSpawnPoint.rotation);
    }
}
