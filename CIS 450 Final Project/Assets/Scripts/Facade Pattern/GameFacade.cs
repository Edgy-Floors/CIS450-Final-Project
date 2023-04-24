using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameFacade : MonoBehaviour
{
    public PauseMenu p;
    public ResourceTracker r;

    public void PauseGame()
    {
        p.PauseGame();
    }

    public void ResumeGame()
    {
        p.ResumeGame();
    }

    public void QuitGame()
    {
        p.QuitGame();
    }

    public void GetResources()
    {
        r.GetResources();
    }

    public void GainResources(int i)
    {
        r.GainResources(i);
    }

    public void SpendResources(int i)
    {
        r.SpendResources(i);
    }
}
