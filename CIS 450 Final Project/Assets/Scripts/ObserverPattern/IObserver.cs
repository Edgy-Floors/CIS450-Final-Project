using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class IObserver : MonoBehaviour
{
    public abstract void UpdateData(float currentTemp, float maxTemp, int treeCount, int co2Count);
}
