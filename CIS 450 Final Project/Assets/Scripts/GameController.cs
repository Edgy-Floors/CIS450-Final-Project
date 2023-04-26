using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject pauseMenuCanvas;

    public PauseMenu pauseMenuScript;

    private void Start()
    {
        // Finds the pause menu gameobject gets the object and its respective script.
        pauseMenuCanvas = GameObject.FindGameObjectWithTag("Pause Menu");
        pauseMenuScript = pauseMenuCanvas.GetComponent<PauseMenu>();
        pauseMenuCanvas.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape)) 
        {
            pauseMenuCanvas.SetActive(true);
            pauseMenuScript.PauseGame();
        }
    }
}
