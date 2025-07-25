using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu_Manager : MonoBehaviour
{
    public static PauseMenu_Manager Instance;

    [SerializeField] GameObject Pause;
    public bool Game;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

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
       
        //Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        Pause.SetActive(true);
        Game = false;
    }
    void ResumeMenu()
    {
        //Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
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
