using UnityEngine;
using UnityEngine.SceneManagement;

public class Level_1_Manager : MonoBehaviour
{
    GameObject loadscripts;
    private void Start() {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void nextlevel()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Level_2");
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        
    }

    public void Retry()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Level_1");
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void Mainmenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void Exit()
    {
        Application.Quit();
    }
}
