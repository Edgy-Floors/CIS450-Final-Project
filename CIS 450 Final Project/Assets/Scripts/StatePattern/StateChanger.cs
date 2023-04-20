using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateChanger : MonoBehaviour
{
    public static State buildingState;
    public static State battleState;
    public State currentState;

    public TreeSpawner treeSpawner;
    public GameStateTracker gameStateTracker;
    public CO2Spawner co2Spawner;
    public GameObject continueButton;
    [SerializeField] float battleLength;

    private void Awake()
    {
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
    }

    public IEnumerator EndBattle()
    {
        yield return new WaitForSeconds(battleLength);

        EndState();
    }
}
