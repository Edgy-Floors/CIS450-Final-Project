using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleState : State
{
    StateChanger context;
    IEnumerator battleCoroutine;

    public BattleState(StateChanger newContext)
    {
        context = newContext;
    }

    public void BeginState()
    {
        //Time.timeScale = 1;
        context.gameStateTracker.isRunning = true;
        context.co2Spawner.StartSpawning();

        context.treeSpawner.ToggleButtons(false);
        context.continueButton.SetActive(false);

        battleCoroutine = context.EndBattle();
        context.StartCoroutine(battleCoroutine);
    }

    public void EndState()
    {
        context.StopCoroutine(battleCoroutine);

        context.currentState = StateChanger.buildingState;
        context.BeginState();
    }
}
