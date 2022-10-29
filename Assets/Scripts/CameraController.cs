using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] GameObject tank1;
    [SerializeField] GameObject tank2;
    [SerializeField] private float trackingSpeed = 12f;
    [SerializeField] TankController controller1;
    [SerializeField] TankController controller2;

    private Vector3 target;
    void Update()
    {
        if (controller1.isActiveAndEnabled == true)
        {
            target = new Vector3(tank1.transform.position.x +5, tank1.transform.position.y, -10);
            transform.rotation = Quaternion.Euler(0, 0, 0);
            transform.position = Vector3.MoveTowards(transform.position, target, trackingSpeed * Time.deltaTime);
        }
        if (controller2.isActiveAndEnabled == true)
        {
            target = new Vector3(tank2.transform.position.x -18.5f, tank2.transform.position.y, -10);
            transform.rotation = Quaternion.Euler(0, 0, 0);
            transform.position = Vector3.MoveTowards(transform.position, target, trackingSpeed * Time.deltaTime);
        }
    }
}
