using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TreeTemplate : MonoBehaviour
{
    [SerializeField] protected float absorbtionRange;
    [SerializeField] protected float absorbtionSpeed;

    protected GameStateTracker gameStateTracker;

    protected IEnumerator Absorb()
    {
        while (true)
        {
            if (CheckForCo2())
            {
                AbsorbCo2();
            }

            yield return new WaitForSeconds(absorbtionSpeed);
        }
    }

    protected abstract bool CheckForCo2();

    protected abstract void AbsorbCo2();
}
