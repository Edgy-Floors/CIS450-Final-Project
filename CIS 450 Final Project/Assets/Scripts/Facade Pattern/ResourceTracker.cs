using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ResourceTracker : MonoBehaviour
{
    int resourceCount = 8;

    [SerializeField] TextMeshProUGUI resourceText;
    [SerializeField] TreeSpawner treeSpawner;

    private void Awake()
    {
        treeSpawner.UpdateButtonAvailability(resourceCount);

        resourceText.text = "Volunteers:\n" + resourceCount;
    }

    public int GetResources()
    {
        return resourceCount;
    }

    public void GainResources(int amount)
    {
        resourceCount += amount;

        resourceText.text = "Volunteers:\n" + resourceCount;

        treeSpawner.UpdateButtonAvailability(resourceCount);
    }

    public void SpendResources(int amount)
    {
        resourceCount -= amount;

        resourceText.text = "Volunteers:\n" + resourceCount;

        treeSpawner.UpdateButtonAvailability(resourceCount);
    }
}
