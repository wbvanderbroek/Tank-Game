using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnManager : MonoBehaviour
{
    [SerializeField] GameObject Tank1;
    [SerializeField] GameObject Tank2;
    public void InvokeTank1()
    {
        Invoke("EnableTank1", 2.5f);
    }
    public void InvokeTank2()
    {
        Invoke("EnableTank2", 2.5f);
    }
    private void EnableTank1()
    {
        Tank1.GetComponent<TankController>().enabled = true;
    }
    private void EnableTank2()
    {
        Tank2.GetComponent<TankController2>().enabled = true;
    }
}
