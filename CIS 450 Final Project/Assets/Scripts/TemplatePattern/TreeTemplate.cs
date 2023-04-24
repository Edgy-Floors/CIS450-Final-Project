using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TreeTemplate : MonoBehaviour
{
    [SerializeField] protected int cost;
    [SerializeField] public float absorbtionRange;
    [SerializeField] public float absorbtionSpeed;
    [SerializeField] protected int resourceGain;
    [SerializeField] public string description;

    protected GameStateTracker gameStateTracker;
    protected ResourceTracker resourceTracker;

    protected IEnumerator Absorb()
    {
        while (true)
        {
            if (CheckForCo2())
            {
                resourceTracker.GainResources(resourceGain);
                AbsorbCo2();
            }

            yield return new WaitForSeconds(absorbtionSpeed);
        }
    }

    protected abstract bool CheckForCo2();

    protected abstract void AbsorbCo2();

    public int GetCost()
    {
        return cost;
    }
}
