using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ResourceTracker : MonoBehaviour
{
    int resourceCount = 0;

    [SerializeField] TextMeshProUGUI resourceText;

    public void GainResources(int amount)
    {
        resourceCount += amount;

        resourceText.text = "Volunteers: " + resourceText;

        //UpdateTreeSpawner();
    }

    public void UpdateTreeSpawner()
    {
        //return resourceCount;
    }

    public void SpendResources(int amount)
    {
        resourceCount -= amount;

        resourceText.text = "Volunteers: " + resourceText;
    }
}
