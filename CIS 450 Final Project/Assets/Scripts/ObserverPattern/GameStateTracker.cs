using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateTracker : ISubject
{
    List<IObserver> observerList = new List<IObserver>();

    float currentTemp;
    [SerializeField] float maxTemp;

    // These will be private once other features are implemented, they are public for testing
    public int treeCount = 0;
    public int co2Count = 0;

    [SerializeField] float tempChangeRate;
    [SerializeField] float treeWeight;
    [SerializeField] float co2Weight;

    public bool isRunning = true;

    private void Awake()
    {
        currentTemp = maxTemp / 2;
    }

    public override void NotifyObservers()
    {
        foreach (IObserver observer in observerList)
        {
            observer.UpdateData(currentTemp, maxTemp, treeCount, co2Count);
        }
    }

    public override void RegisterObserver(IObserver observer)
    {
        observerList.Add(observer);
    }

    public override void RemoveObserver(IObserver observer)
    {
        if (observerList.Contains(observer))
        {
            observerList.Remove(observer);
        }
    }

    private void Update()
    {
        if (isRunning)
        {
            float netDifference = (co2Count * co2Weight) - (treeCount * treeWeight);

            currentTemp += netDifference * tempChangeRate * Time.deltaTime;

            if (currentTemp < 0)
            {
                currentTemp = 0;
            }

            NotifyObservers();
        }
    }

    public void UpdateTreeCount(int amount)
    {
        treeCount += amount;

        if (treeCount < 0)
        {
            treeCount = 0;
        }
    }

    public void UpdateCo2Count(int amount)
    {
        co2Count += amount;

        if (co2Count < 0)
        {
            co2Count = 0;
        }
    }

}
