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
        ParticleSpawner();
        Destroy(gameObject);   
    }
    public void ParticleSpawner()
    {
        Instantiate(particleToSpawn, particleSpawnPoint.position, particleSpawnPoint.rotation);
    }
}
