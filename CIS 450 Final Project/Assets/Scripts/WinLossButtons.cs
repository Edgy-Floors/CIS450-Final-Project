using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinLossButtons : MonoBehaviour
{
    public void RetryButtonClicked()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void ReturnToMenuClicked()
    {
        SceneManager.LoadScene(0);
    }
}
