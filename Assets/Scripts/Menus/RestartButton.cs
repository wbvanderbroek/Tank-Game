using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class RestartButton : MonoBehaviour
{
    public void Resetbutton()
    {
        SceneManager.LoadScene(sceneBuildIndex:1);
        Physics2D.gravity = new Vector2(0, -9.8f);
    }
}
