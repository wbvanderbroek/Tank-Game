using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleDestroyer : MonoBehaviour
{
    void Start()
    {
        Invoke("Destroy", 2.5f);
    }
    private void Destroy()
    {
        Destroy(gameObject);
    }
}
