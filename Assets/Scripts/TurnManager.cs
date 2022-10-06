using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnManager : MonoBehaviour
{
    [SerializeField] GameObject Tank1;
    [SerializeField] GameObject Tank2;
    [SerializeField] GameObject Bullet;
    private int TotalAmount = 0;

    private void Update()
    {
        TotalAmount = GameObject.FindGameObjectsWithTag("Bullet").Length;
    }
    public void InvokeTank1()
    {
        Invoke("EnableTank1", 1f);
    }
    public void InvokeTank2()
    {
        Invoke("EnableTank2", 1f);
    }
    private void EnableTank1()
    {
        if (TotalAmount == 0)
        {
            Tank1.GetComponent<TankController>().enabled = true;
        }
        else
        {
            Invoke("InvokeTank11", 0.5f);
        }
    }
    private void EnableTank2()
    {
        if (TotalAmount == 0)
        {
            Tank2.GetComponent<TankController2>().enabled = true;
        }
        else
        {
            Invoke("InvokeTank22", 0.5f);  
        }
    }
    private void InvokeTank11 ()
    {
        EnableTank1 ();
    }
    private void InvokeTank22()
    {
        EnableTank2();
    }
}
