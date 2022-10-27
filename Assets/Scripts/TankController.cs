using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankController : MonoBehaviour
{
    [SerializeField] Transform barrelRotator;
    [SerializeField] Transform firePoint;
    [SerializeField] GameObject bulletToFire;
    [SerializeField] GameObject Tank1;
    [SerializeField] GameObject Tank2;
    [SerializeField] Sprite inactiveSprite;
    [SerializeField] Sprite activeSprite;
    [SerializeField] TankController controller1;
    [SerializeField] TankController controller2;
    private float bulletPower = 15f;
    private float cooldownOnShots = 0f;
    private float player1Turn = 0f;
    private float player2Turn = 0f;

    private Rigidbody2D rb;
    private float dirX = 0f;
    private float moveSpeed = 3f;

    void Start()
    {
        controller1 = controller1.GetComponent<TankController>();
        controller2 = controller2.GetComponent<TankController>();
        rb = GetComponent<Rigidbody2D>(); 
    }
    private void OnEnable()
    {
        GetComponentInChildren<SpriteRenderer>().sprite = activeSprite;

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
        if (player1Turn == 3)
        {
            GameObject.Find("Main Camera").GetComponent<TurnManager>().InvokeTank1();
            GetComponentInChildren<SpriteRenderer>().sprite = inactiveSprite; 
            GetComponent<TankController>().enabled = false;
            player1Turn = 0;
        }
        if (player2Turn == 3)
        {
            GameObject.Find("Main Camera").GetComponent<TurnManager>().InvokeTank2();
            GetComponentInChildren<SpriteRenderer>().sprite = inactiveSprite;
            GetComponent<TankController>().enabled = false;
            player2Turn = 0;
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
            
            if (controller1.isActiveAndEnabled == true)
            {
                player1Turn = player1Turn + 1;
            }
            if (controller2.isActiveAndEnabled == true)
            {
                player2Turn = player2Turn + 1;
            }
        }
    }
}
