using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
    public void LoadFirstLevel()
    {
        SceneManager.LoadScene("Level 1");
    }

    public void LoadSecondLevel()
    {
        SceneManager.LoadScene("Level 2");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}