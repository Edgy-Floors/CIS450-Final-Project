using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateChanger : MonoBehaviour
{
    public static State buildingState;
    public static State battleState;
    public static State winLossState;
    public State currentState;

    private void Awake()
    {

    }

    public void BeginState()
    {
        currentState.BeginState();
    }

    public void EndState()
    {
        currentState.EndState();
    }
}
