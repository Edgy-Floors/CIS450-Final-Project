using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinLossButtons : MonoBehaviour
{
    public void RetryButtonClicked()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void ReturnToMenuClicked()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(0);
    }
}
