using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu_Manager : MonoBehaviour
{
     public void startMenu()
     {
        SceneManager.LoadScene("Level_1");
        Time.timeScale = 1f;
    }

    public void endMenu()
    {
        Application.Quit();
    }
}
