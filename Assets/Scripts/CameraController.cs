using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] Transform tank1;
    [SerializeField] Transform tank2;
    private Transform bullet;
    [SerializeField] private float trackingSpeed = 2.3f;
    [SerializeField] private float bulletTrackingSpeed = 15f;
    [SerializeField] TankController controller1;
    [SerializeField] TankController controller2;
    private int TotalBulletsInScene = 0;

    private Vector3 target;
    void Update()
    {
        
        TotalBulletsInScene = GameObject.FindGameObjectsWithTag("Bullet").Length;
        if (TotalBulletsInScene == 1)
        {
            bullet = GameObject.Find("Bullet(Clone)").GetComponent<Transform>();
            target = new Vector3(bullet.transform.position.x, bullet.transform.position.y, -10);
            transform.rotation = Quaternion.Euler(0, 0, 0);
            transform.position = Vector3.MoveTowards(transform.position, target, bulletTrackingSpeed * Time.deltaTime);
        }
        if (controller1.isPlayerTurn == true)
        {
            target = new Vector3(tank1.transform.position.x +8, tank1.transform.position.y +4, -10);
            transform.rotation = Quaternion.Euler(0, 0, 0);
            transform.position = Vector3.MoveTowards(transform.position, target, trackingSpeed * Time.deltaTime);
        }
        if (controller2.isPlayerTurn == true)
        {
            target = new Vector3(tank2.transform.position.x -8, tank2.transform.position.y +4, -10);
            transform.rotation = Quaternion.Euler(0, 0, 0);
            transform.position = Vector3.MoveTowards(transform.position, target, trackingSpeed * Time.deltaTime);
        }
    }
}
