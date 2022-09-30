using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankController : MonoBehaviour
{
    [SerializeField]
    Transform barrelRotator;
    [SerializeField]
    Transform firePoint;
    [SerializeField]
    GameObject bulletToFire;
    [SerializeField]
    GameObject particleToSpawn;
    private float bulletPower = 15f;
    private Rigidbody2D rb;
    private float dirX = 0f;
    private float moveSpeed = 10f;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            if(bulletPower > 5)
            {
                bulletPower = bulletPower - 1;
            }
        }
        if (Input.GetMouseButtonDown(0))
        {
            if (bulletPower < 20)
            {
                bulletPower = bulletPower + 1;
            } 
        }
        dirX = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);
        //float ClampedInput = Mathf.Clamp(Input.GetAxis("Vertical"), 0f, 1f);
        //Vector3 ClampedAngle = Mathf.Clamp
        barrelRotator.RotateAround(Vector3.forward, Input.GetAxis("Vertical") * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject b = Instantiate(bulletToFire, firePoint.position, firePoint.rotation);
            b.GetComponent<Rigidbody2D>().AddForce(barrelRotator.up * bulletPower, ForceMode2D.Impulse);
            Instantiate(particleToSpawn, firePoint.position, firePoint.rotation );
        }
    }
}
