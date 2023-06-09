using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TreeSpawner : MonoBehaviour
{
    [SerializeField] List<GameObject> treePrefabs;
    [SerializeField] List<Button> buttonList;
    [SerializeField] Vector2 xPosBounds;
    [SerializeField] Vector2 yPosBounds;
    [SerializeField] ResourceTracker resourceTracker;
    [SerializeField] TreeInfo treeInfo;
    [SerializeField] RangeIndicator rangeIndicator;

    bool canBeInteractable;
    bool hasClickedOnce = false;
    int currentIndex = -1;

    public void OnClick(int optionClicked)
    {
        hasClickedOnce = true;
        currentIndex = optionClicked;

        treeInfo.EnableDescription(buttonList[optionClicked].transform.position.y,
            treePrefabs[optionClicked].GetComponent<TreeTemplate>());

        if (currentIndex == 3)
        {
            MortarTree mortarTemplate = treePrefabs[currentIndex].GetComponent<MortarTree>();
            rangeIndicator.ActivateIndicator(mortarTemplate.absorbtionRange, mortarTemplate.minAbsorbtionRange);
        }
        else
        {
            TreeTemplate template = treePrefabs[currentIndex].GetComponent<TreeTemplate>();
            rangeIndicator.ActivateIndicator(template.absorbtionRange);
        }
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && hasClickedOnce)
        {
            rangeIndicator.DeactivateIndicator();

            treeInfo.DisableDescription();

            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            if ((mousePos.x >= xPosBounds.x && mousePos.x <= xPosBounds.y) && 
                (mousePos.y >= yPosBounds.x && mousePos.y <= yPosBounds.y))
            {
                hasClickedOnce = false;
                Instantiate(treePrefabs[currentIndex], mousePos, Quaternion.identity);
                int cost = treePrefabs[currentIndex].GetComponent<TreeTemplate>().GetCost();
                resourceTracker.SpendResources(cost);
            }
        }
    }

    public void UpdateButtonAvailability(int currentResources)
    {
        if (canBeInteractable)
        {
            for (int i = 0; i < buttonList.Count && i < treePrefabs.Count; ++i)
            {
                if (treePrefabs[i].GetComponent<TreeTemplate>().GetCost() > currentResources)
                {
                    buttonList[i].interactable = false;
                }
                else
                {
                    buttonList[i].interactable = true;
                }
            }
        }
    }

    public void ToggleButtons(bool isActive)
    {
        foreach (Button treeButton in buttonList)
        {
            canBeInteractable = isActive;
            treeButton.interactable = isActive;
            UpdateButtonAvailability(resourceTracker.GetResources());
        }
    }
}
