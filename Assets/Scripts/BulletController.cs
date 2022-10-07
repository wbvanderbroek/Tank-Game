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
            Debug.Log("tank1 hit");
        }
        if (collision.gameObject.name == "Tank2")
        {
            Debug.Log("tank2 hit");
        }
        ParticleSpawner();
        Destroy(gameObject);

    }
    public void ParticleSpawner()
    {
        Instantiate(particleToSpawn, particleSpawnPoint.position, particleSpawnPoint.rotation);
    }
}
