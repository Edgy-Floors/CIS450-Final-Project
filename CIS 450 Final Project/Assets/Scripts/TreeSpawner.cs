using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeSpawner : MonoBehaviour
{
    [SerializeField] List<GameObject> treePrefabs;
    [SerializeField] Vector2 xPosBounds;
    [SerializeField] Vector2 yPosBounds;

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
            }
        }
    }
}
