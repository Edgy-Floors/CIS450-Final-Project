using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinLossState : State
{
    StateChanger context;

    public WinLossState(StateChanger newContext)
    {
        context = newContext;
    }

    public void BeginState()
    {
        throw new System.NotImplementedException();
    }

    public void EndState()
    {
        throw new System.NotImplementedException();
    }
}
