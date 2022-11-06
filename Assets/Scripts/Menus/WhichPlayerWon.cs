using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WhichPlayerWon : MonoBehaviour
{
    [SerializeField] Text whoWonText;
    private string player1Won = "player 1 wins";
    private string player2Won = "player 2 wins";
    void Start()
    {
        if (HealthManager.player1won == true)
        {
            whoWonText.text = player1Won.ToString();
            HealthManager.player1won = false;
        }
        if (HealthManager.player2won == true)
        {
            whoWonText.text = player2Won.ToString();
            HealthManager.player2won = false;
        }
    }
}