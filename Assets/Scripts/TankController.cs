using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;
public class TankController : MonoBehaviour
{
    [SerializeField] Transform barrelRotator;
    private float rotationZ1 = -70f;
    private float rotationZ2 = -70f;
    private int barrelRotationSpeed = 15;

    [SerializeField] Transform firePoint;
    [SerializeField] GameObject bulletToFire;
    public int bulletPower = 15;
    private float cooldownOnShots = 0f;

    [SerializeField] GameObject Tank1;
    [SerializeField] GameObject Tank2;
    [SerializeField] Sprite inactiveSprite;
    [SerializeField] Sprite activeSprite;
    [SerializeField] TankController controller1;
    [SerializeField] TankController controller2;
    [SerializeField] Camera cam;

    [SerializeField] Image bullets3Leftplayer1;
    [SerializeField] Image bullets2Leftplayer1;
    [SerializeField] Image bullets1Leftplayer1;

    [SerializeField] Image bullets3Leftplayer2;
    [SerializeField] Image bullets2Leftplayer2;
    [SerializeField] Image bullets1Leftplayer2;

    private int player1Turn = 0;
    private int player2Turn = 0;
    public bool isPlayer1Turn = true;
    public bool isPlayer2Turn = true;

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
        if (isPlayer1Turn == true)
        {
            GetComponentInChildren<SpriteRenderer>().sprite = activeSprite;
            bullets1Leftplayer1.enabled = true;
            bullets2Leftplayer1.enabled = true;
            bullets3Leftplayer1.enabled = true;
        }
        if (isPlayer2Turn == true)
        {
            GetComponentInChildren<SpriteRenderer>().sprite = activeSprite;
            bullets1Leftplayer2.enabled = true;
            bullets2Leftplayer2.enabled = true;
            bullets3Leftplayer2.enabled = true;
        }
    }
    void Update()
    {
        if (isPlayer1Turn == true)
        {
            BulletVisualizerUI();
            Movement();
            CooldownOnSBullets();
            Shoot();
            PlayerTurnManager();
            BulletPowerAdjuster();
        }
        if (isPlayer2Turn == true)
        {
            BulletVisualizerUI();
            Movement();
            CooldownOnSBullets();
            Shoot();
            PlayerTurnManager();
            BulletPowerAdjuster();
        }


    }
    private void BulletVisualizerUI()
    {
        if (isPlayer1Turn == true)
        {
            if (player1Turn == 1)
            {
                bullets1Leftplayer1.enabled = false;
            }
            if (player1Turn == 2)
            {
                bullets2Leftplayer1.enabled = false;
            }
            if (player1Turn == 3)
            {
                bullets3Leftplayer1.enabled = false;
            }
        }
        if (isPlayer2Turn == true)
        {
            if (player2Turn == 1)
            {
                bullets1Leftplayer2.enabled = false;
            }
            if (player2Turn == 2)
            {
                bullets2Leftplayer2.enabled = false;
            }
            if (player2Turn == 3)
            {
                bullets3Leftplayer2.enabled = false;
            }
        }
    }
    private void CooldownOnSBullets()
    {
        if (cooldownOnShots > 0)
        {
            cooldownOnShots -= Time.deltaTime;
        }
    }
    private void Shoot()
    {
        if (Input.GetKeyDown(KeyCode.Space) && (cooldownOnShots <= 0))
        {
            cooldownOnShots = 1.0f;
            GameObject b = Instantiate(bulletToFire, firePoint.position, firePoint.rotation);
            b.GetComponent<Rigidbody2D>().AddForce(barrelRotator.up * bulletPower, ForceMode2D.Impulse);

            if (isPlayer1Turn == true)
            {
                player1Turn = player1Turn + 1;
            }
            if (isPlayer2Turn == true)
            {
                player2Turn = player2Turn + 1;
            }
        }
    }
    private void Movement()
    {
        dirX = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);
        if (isPlayer1Turn == true)
        {
            rotationZ1 -= Input.GetAxis("Vertical") * Time.deltaTime * barrelRotationSpeed * -1;
            rotationZ1 = Mathf.Clamp(rotationZ1, -95, -45);
            barrelRotator.transform.eulerAngles = new Vector3(0, 0, rotationZ1);
        }
        if (isPlayer2Turn == true)
        {
            rotationZ2 -= Input.GetAxis("Vertical") * Time.deltaTime * barrelRotationSpeed * -1;
            rotationZ2 = Mathf.Clamp(rotationZ2, -95, -45);
            barrelRotator.transform.eulerAngles = new Vector3(0, 180, rotationZ2);
        }
    }
    private void PlayerTurnManager()
    {
        if (player1Turn == 3)
        {
            GameObject.Find("Main Camera").GetComponent<TurnManager>().InvokeTank1();
            GetComponentInChildren<SpriteRenderer>().sprite = inactiveSprite;
            isPlayer1Turn = false;
            player1Turn = 0;
        }
        if (player2Turn == 3)
        {
            GameObject.Find("Main Camera").GetComponent<TurnManager>().InvokeTank2();
            GetComponentInChildren<SpriteRenderer>().sprite = inactiveSprite;
            isPlayer2Turn = false;
            player2Turn = 0;
        }
    }
    private void BulletPowerAdjuster()
    {
        if (Input.GetMouseButtonDown(1))
        {
            if (bulletPower > 8)
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
    }

}

