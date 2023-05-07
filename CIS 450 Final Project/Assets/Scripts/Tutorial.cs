using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;

public class Tutorial : MonoBehaviour
{
    public TextMeshProUGUI TutorialText;
    
    public GameObject firstTree;
    private float changeText;

    bool initialChange = false;
    bool treespawned = false;

    // Start is called before the first frame update
    void Start()
    {
        UpdateText(0);
        changeText = Time.time + 2;
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time > changeText && !initialChange)
        {
            UpdateText(1);
            initialChange = true;
        }

        if (firstTree == null)
        {
            firstTree = GameObject.FindGameObjectWithTag("Tree");
        }
        else if (!treespawned && firstTree != null)
        {
            treespawned = true;
            UpdateText(2);
        }
    }

    public void UpdateText(int tutorialPhase)
    {
        switch (tutorialPhase)
        {
            case 0:
                TutorialText.text = "Welcome to the Tutorial!";
                break;
            case 1:
                TutorialText.text = "Use the mouse left click to select and then place a tree anywhere on the map.";
                break;
            case 2:
                TutorialText.text = "Click 'End Building' when ready";
                break;
            case 3:
                TutorialText.text = "Tutorial Complete! Enjoy the game!";
                StartCoroutine(DisableTutorialText());
                break;

        }
    }

    private IEnumerator DisableTutorialText()
    {
        yield return new WaitForSeconds(3f);

        this.gameObject.SetActive(false);
        StopAllCoroutines();
    }
}
