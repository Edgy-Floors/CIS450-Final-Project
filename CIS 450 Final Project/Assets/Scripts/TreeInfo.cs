using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TreeInfo : MonoBehaviour
{
    [SerializeField] GameObject treeDescription;
    [SerializeField] TextMeshProUGUI descriptionText;

    public void EnableDescription(float yPos, TreeTemplate tree)
    {
        treeDescription.SetActive(true);

        treeDescription.transform.position = new Vector2(treeDescription.transform.position.x, yPos);

        descriptionText.text = "Cost: " + tree.GetCost() + "\n" + tree.description;
    }

    public void DisableDescription()
    {
        treeDescription.SetActive(false);
    }
}
