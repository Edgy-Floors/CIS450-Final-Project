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

    [SerializeField] StateChanger stateChanger;
    int netWaves = 0;
    int currentWaveCount;

    public CircleCollider2D rangeCollider;

    protected GameStateTracker gameStateTracker;
    protected GameFacade gameFacade;

    protected IEnumerator Absorb()
    {
        while (true)
        {
            if (CheckForCo2())
            {
                gameFacade.GainResources(resourceGain);
                AbsorbCo2();
            }

            yield return new WaitForSeconds(absorbtionSpeed);
        }
    }

    protected abstract bool CheckForCo2();

    protected abstract void AbsorbCo2();

    protected void Update()
    {
        //if (netWaves <= 2 && currentWaveCount != stateChanger.wave)
        //{
        //    netWaves += stateChanger.wave - currentWaveCount;
        //    currentWaveCount = stateChanger.wave;

        //    if (netWaves == 2)
        //    {

        //    }
        //}
    }

    public int GetCost()
    {
        return cost;
    }
}
