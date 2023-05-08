using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbsorptionIncreaser : TreeModifier
{
    protected override bool CheckForCo2()
    {
        return this.CheckForCo2();
    }

    protected override void AbsorbCo2()
    {
        this.AbsorbCo2();
    }

    private void Awake()
    {
        addAbsorptionSpeed(0.25f);
    }
}
