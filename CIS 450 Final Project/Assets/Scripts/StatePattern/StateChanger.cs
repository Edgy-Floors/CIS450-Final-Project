using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateChanger : MonoBehaviour
{
    public bool isInTutorial;
    public Tutorial tutorialScript;
    public static State buildingState;
    public static State battleState;
    public State currentState;
    public int wave = 0;

    public TreeSpawner treeSpawner;
    public GameStateTracker gameStateTracker;
    public CO2Spawner co2Spawner;
    public GameObject continueButton;
    [SerializeField] float battleLength;


    private void Awake()
    {
        if(isInTutorial)
        {
            tutorialScript = GameObject.FindGameObjectWithTag("TutorialText").GetComponent<Tutorial>();
        }

        GameObject temp = GameObject.FindGameObjectWithTag("GameController");
        treeSpawner = temp.GetComponent<TreeSpawner>();
        gameStateTracker = temp.GetComponent<GameStateTracker>();

        buildingState = new BuildingState(this);
        battleState = new BattleState(this);

        currentState = buildingState;
        BeginState();
    }

    public void BeginState()
    {
        currentState.BeginState();
    }

    public void EndState()
    {
        currentState.EndState();

        if(isInTutorial)
        {
            tutorialScript.UpdateText(3);
        }
    }

    public IEnumerator EndBattle()
    {
        yield return new WaitForSeconds(battleLength);
        EndState();
    }
}
