using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingState : State
{
    StateChanger context;

    public BuildingState(StateChanger newContext)
    {
        context = newContext;
    }

    public void BeginState()
    {
        //Time.timeScale = 0;
        context.gameStateTracker.isRunning = false;
        context.co2Spawner.StopSpawning();

        context.treeSpawner.ToggleButtons(true);
        context.continueButton.SetActive(true);
    }

    public void EndState()
    {
        context.currentState = StateChanger.battleState;
        context.BeginState();
    }
}
