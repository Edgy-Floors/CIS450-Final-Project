using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
    [Tooltip("The level name must be typed exactly as it is saved as.")]
    public string levelName;
    public void StartGame()
    {
        SceneManager.LoadScene(levelName);
    }
}