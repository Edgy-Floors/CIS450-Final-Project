using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ISubject : MonoBehaviour
{
    public abstract void RegisterObserver(IObserver observer);

    public abstract void RemoveObserver(IObserver observer);

    public abstract void NotifyObservers();
}
