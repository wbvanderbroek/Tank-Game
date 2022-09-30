using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        Instantiate(particleToSpawn, particleSpawnPoint.position, particleSpawnPoint.rotation);
        Destroy(gameObject);   
    }
}
