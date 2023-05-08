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
        t.rangeCollider.radius = t.absorbtionRange;
        Debug.Log("New Range: " + t.absorbtionRange);
    }

    public void addAbsorptionSpeed(float absToAdd)
    {
        if (t.absorbtionRange > 1f)
        {
            t.absorbtionSpeed -= absToAdd;
            Debug.Log("New Speed: " + t.absorbtionSpeed);
        }
    }
}
