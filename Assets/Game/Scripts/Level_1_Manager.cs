using UnityEngine;
using UnityEngine.SceneManagement;

public class Level_1_Manager : MonoBehaviour
{
    private void Start() {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void nextlevel()
    {
        SceneManager.LoadScene("Level_2");
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        
    }

    public void Retry()
    {
        SceneManager.LoadScene("Level_1");
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void Mainmenu()
    {
        SceneManager.LoadScene("Menu");
        Time.timeScale = 1f;
    }

    public void Exit()
    {
        Application.Quit();
    }
}
