using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu_Manager : MonoBehaviour
{
    [SerializeField] GameObject Pause;
    bool Game;
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if (Game)
            {
                PauseMenu();
            }
            else if(!Game)
            {
                ResumeMenu();
            }
        }
    }
    void PauseMenu()
    {
       
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        Time.timeScale = 0f;
        Pause.SetActive(true);
        Game = false;
    }
    void ResumeMenu()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        Time.timeScale = 1f;
        Pause.SetActive(false);
        Game = true;
    }

    public void Resume()
    {
        ResumeMenu();
    }
    public void menu()
    {
        SceneManager.LoadScene("Menu");
    }
    public void Exit()
    {
        Application.Quit();
    }

}
