using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

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

    [SerializeField] Image bullets3Leftplayer1;
    [SerializeField] Image bullets2Leftplayer1;
    [SerializeField] Image bullets1Leftplayer1;

    [SerializeField] Image bullets3Leftplayer2;
    [SerializeField] Image bullets2Leftplayer2;
    [SerializeField] Image bullets1Leftplayer2;

    private float rotationZ1 = 0.0f;
    private float rotationZ2 = 0.0f;
    private int barrelRotationSpeed = 15;
    public int bulletPower = 15;
    private float cooldownOnShots = 0f;
    private float player1Turn = 0f;
    private float player2Turn = 0f;
    private float maxBarrelRotation;
    private float barrelRotationAngle;

    private Rigidbody2D rb;
    private float dirX = 0f;
    private float moveSpeed = 3f;

    [SerializeField] Camera cam;
    void Start()
    {
        controller1 = controller1.GetComponent<TankController>();
        controller2 = controller2.GetComponent<TankController>();
        rb = GetComponent<Rigidbody2D>(); 
    }
    private void OnEnable()
    {
        GetComponentInChildren<SpriteRenderer>().sprite = activeSprite;
        if (controller1.isActiveAndEnabled == true)
        {
            //cam.transform.SetParent(transform);
            //cam.transform.position = Tank1.transform.position + new Vector3(0, 0, -10); ;
            bullets1Leftplayer1.enabled = true;
            bullets2Leftplayer1.enabled = true;
            bullets3Leftplayer1.enabled = true;
        }
        if (controller2.isActiveAndEnabled == true)
        { 
            //cam.transform.SetParent(transform);
            //cam.transform.position = Tank2.transform.position + new Vector3(0, 0, -10);
            bullets1Leftplayer2.enabled = true;
            bullets2Leftplayer2.enabled = true;
            bullets3Leftplayer2.enabled = true;
        }
    }

    void Update()
    {
        if (controller1.isActiveAndEnabled == true)
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
        if (controller2.isActiveAndEnabled == true)
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
        if (cooldownOnShots > 0)
        {
            cooldownOnShots -= Time.deltaTime;
        }

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
        
        if (controller1.isActiveAndEnabled == true)
        {
            rotationZ1 -= Input.GetAxis("Vertical") * Time.deltaTime * barrelRotationSpeed * -1;
            rotationZ1 = Mathf.Clamp(rotationZ1 ,- 90, -45);
            barrelRotator.transform.eulerAngles = new Vector3(0, 0, rotationZ1);
            

            //barrelRotator.transform.Rotate(Vector3.forward, barrelRotationAngle, Space.Self);
            //Mathf.Clamp(barrelRotator.transform.rotation.eulerAngles.z, -90, -45);
            //barrelRotator.transform.rotation = Quaternion.Euler(0, 0, Mathf.Clamp(transform.rotation.eulerAngles.y, -30f, -90f));

            /*if ((barrelRotator.transform.rotation.eulerAngles.z > 270) && (barrelRotator.transform.rotation.eulerAngles.z < 315))
            {
                barrelRotator.transform.Rotate(Vector3.forward, Input.GetAxis("Vertical") * Time.deltaTime * barrelRotationSpeed);
                Debug.Log("sdfjk"); 
            } */
        }
        if (controller2.isActiveAndEnabled == true)
        {
            rotationZ2 -= Input.GetAxis("Vertical") * Time.deltaTime * barrelRotationSpeed * -1;
            rotationZ2 = Mathf.Clamp(rotationZ2, -90, -45);
            barrelRotator.transform.eulerAngles = new Vector3(0, 180, rotationZ2);            
        }
        
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
