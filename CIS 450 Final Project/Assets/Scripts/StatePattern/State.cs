using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface State
{
    public abstract void BeginState();

    public abstract void EndState();
}
