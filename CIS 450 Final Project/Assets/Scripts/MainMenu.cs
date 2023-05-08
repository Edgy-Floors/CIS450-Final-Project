using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
    public void LoadFirstLevel()
    {
        SceneManager.LoadScene("Exposition Scene");
        TextDisplay.sceneToLoad = "Level 1";
    }

    public void LoadSecondLevel()
    {
        SceneManager.LoadScene("Exposition Scene");
        TextDisplay.sceneToLoad = "Level 2";
    }

    public void LoadTutorial()
    {
        SceneManager.LoadScene("Tutorial");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}