using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankController : MonoBehaviour
{
    [SerializeField] Transform barrelRotator;
    [SerializeField] Transform firePoint;
    [SerializeField] GameObject bulletToFire;
    [SerializeField] GameObject Tank2;
    [SerializeField] Material inactiveMat;
    [SerializeField] Material activeMat;
    private float bulletPower = 15f;
    private Rigidbody2D rb;
    private float dirX = 0f;
    private float moveSpeed = 3f;
    private float playerTurn = 0f;
    private float cooldownOnShots = 0f;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

    }
    private void OnEnable()
    {
        GetComponentInChildren<SpriteRenderer>().material = activeMat;
        
    }
    void Update()
    {
        if (cooldownOnShots > 0)
        {
            cooldownOnShots -= Time.deltaTime;
        }

        if (Input.GetMouseButtonDown(1))
        {
            if (bulletPower > 5)
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
        if (playerTurn == 3)
        {
            GameObject.Find("Main Camera").GetComponent<TurnManager>().InvokeTank2();
            GetComponentInChildren<SpriteRenderer>().material = inactiveMat;
            GetComponent<TankController>().enabled = false;
            playerTurn = 0;
        }
        dirX = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);
        //float ClampedInput = Mathf.Clamp(Input.GetAxis("Vertical"), 0f, 1f);
        //Vector3 ClampedAngle = Mathf.Clamp
        barrelRotator.RotateAround(Vector3.forward, Input.GetAxis("Vertical") * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.Space) && (cooldownOnShots <= 0))
        {
            cooldownOnShots = 1.0f;
            GameObject b = Instantiate(bulletToFire, firePoint.position, firePoint.rotation);
            b.GetComponent<Rigidbody2D>().AddForce(barrelRotator.up * bulletPower, ForceMode2D.Impulse);
            playerTurn = playerTurn + 1;
        }
    }
}
