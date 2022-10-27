using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public int player1Score = 0;
    public int player2Score = 0;
    public Text p1Text;
    public Text p2Text;
    public Text bulletPower1;
    public Text bulletPower2;
    [SerializeField] TankController tankController1;
    [SerializeField] TankController tankController2;

    private void Start()
    {
        tankController1 = tankController1.GetComponent<TankController>();
        tankController2 = tankController2.GetComponent<TankController>();
    }
    private void Update()
    {
        
       bulletPower1.text = tankController1.bulletPower.ToString();
       bulletPower2.text = tankController2.bulletPower.ToString();
    }
    public void AddP1Score()
    {
        player1Score++;
        p1Text.text = player1Score.ToString();
    }
    public void AddP2Score()
    {
        player2Score++;
        p2Text.text = player2Score.ToString();
    }
}
