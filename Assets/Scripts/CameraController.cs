using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] Transform tank1;
    [SerializeField] Transform tank2;
    private Transform bullet;
    [SerializeField] private float trackingSpeed = 2.3f;
    [SerializeField] TankController controller1;
    [SerializeField] TankController controller2;
    private int TotalBulletsInScene = 0;
    public bool movingToPlayer1 = false;
    public bool movingToPlayer2 = false;
    public bool allowMoveAndShoot = false;


    private void Start()
    {
        movingToPlayer1 = true;
    }
    private Vector3 target;
    void Update()
    {
        if (controller1.dirX < -0.02f || controller1.dirX > 0.02f)
        {
            if (controller1.isPlayerTurn == true && movingToPlayer1 == false)
            {
                target = new Vector3(tank1.transform.position.x + 8, tank1.transform.position.y + 3.353567f, -10);
                transform.rotation = Quaternion.Euler(0, 0, 0);
                transform.position = target;
            }  
        }
        if (controller2.dirX < -0.02f || controller2.dirX > 0.02f)
        {
            if (controller2.isPlayerTurn == true && movingToPlayer2 == false)
            {
                target = new Vector3(tank2.transform.position.x - 8, tank2.transform.position.y + 3.353567f, -10);
                transform.rotation = Quaternion.Euler(0, 0, 0);
                transform.position = target;
            }
        }
        TotalBulletsInScene = GameObject.FindGameObjectsWithTag("Bullet").Length;
        if (TotalBulletsInScene == 0)
        {
            allowMoveAndShoot = true;
        }
        else
        {
            allowMoveAndShoot = false;
        }
        if (TotalBulletsInScene == 1)
        {
            bullet = GameObject.Find("Bullet(Clone)").GetComponent<Transform>();
            target = new Vector3(bullet.transform.position.x, bullet.transform.position.y, -10);
            transform.rotation = Quaternion.Euler(0, 0, 0);
            transform.position = target;
        } 
        if (controller1.isPlayerTurn == true)
        {
            target = new Vector3(tank1.transform.position.x +8, tank1.transform.position.y + 3.353567f, -10);
            transform.rotation = Quaternion.Euler(0, 0, 0);
            if (movingToPlayer1 == true)
            {
                allowMoveAndShoot = false;
                transform.position = Vector3.MoveTowards(transform.position, target, trackingSpeed * Time.deltaTime);
            }

            if (transform.position == target)
            {
                allowMoveAndShoot = true;
                movingToPlayer1 = false;
            }
        }
        if (controller2.isPlayerTurn == true)
        {
            
            target = new Vector3(tank2.transform.position.x -8, tank2.transform.position.y + 3.353567f, -10);
            transform.rotation = Quaternion.Euler(0, 0, 0);
            if (movingToPlayer2 == true)
            {
                allowMoveAndShoot = false;
                transform.position = Vector3.MoveTowards(transform.position, target, trackingSpeed * Time.deltaTime);
            }
            if (transform.position == target)
            {
                allowMoveAndShoot = true;
                movingToPlayer2 = false;
            }
        }
    }
}
