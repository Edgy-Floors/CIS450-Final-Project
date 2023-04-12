using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject pauseMenuCanvas;

    public PauseMenu pauseMenuScript;

    // Start is called before the first frame update
    void Start()
    {
        
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
