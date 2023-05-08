using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TreeModifier : TreeTemplate
{
    protected TreeTemplate t;

    public TreeModifier()
    {
        t = this;
    }

    public void addRange(float rangeToAdd)
    {
        t.absorbtionRange += rangeToAdd;
        Debug.Log("New Range: " + t.absorbtionRange);
    }

    public void addAbsorptionSpeed(float absToAdd)
    {
        t.absorbtionSpeed += absToAdd;
        Debug.Log("New Speed: " + t.absorbtionSpeed);
    }
}
