using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TreeTemplate : MonoBehaviour
{
    [SerializeField] protected float absorbtionRange;
    [SerializeField] protected float absorbtionSpeed;

    protected void Update()
    {
        if (CheckForCo2())
        {
            AbsorbCo2();
        }
    }

    protected abstract bool CheckForCo2();

    protected abstract void AbsorbCo2();
}
