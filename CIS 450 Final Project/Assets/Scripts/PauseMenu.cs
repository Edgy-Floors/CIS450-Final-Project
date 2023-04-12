using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenu;

    private bool isGamePaused;

    // Start is called before the first frame update
    void Start()
    {
        pauseMenu = this.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if(!isGamePaused)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                PauseGame();
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                ResumeGame();
            }
        }
    }

    private void PauseGame()
    {
        Time.timeScale = 0;
        pauseMenu.SetActive(true);
        isGamePaused = true;

    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
        pauseMenu.SetActive(false);
        isGamePaused = false;
    }

    public void QuitGame()
    {
        SceneManager.LoadScene("Main Menu");
    }
}
