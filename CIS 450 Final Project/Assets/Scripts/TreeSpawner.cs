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

    bool hasClickedOnce = false;
    int currentIndex = -1;

    public void OnClick(int optionClicked)
    {
        hasClickedOnce = true;
        currentIndex = optionClicked;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && hasClickedOnce)
        {
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
