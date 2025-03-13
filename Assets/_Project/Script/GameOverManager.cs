using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    public void Start()
    {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
    }
    public void Retry()
    {
        SceneManager.LoadScene("Scene_1");
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
