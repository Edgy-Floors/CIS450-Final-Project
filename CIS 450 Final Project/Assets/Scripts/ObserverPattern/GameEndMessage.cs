using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEndMessage : IObserver
{
    [SerializeField] GameObject gameLossUI;
    [SerializeField] GameObject gameWinUI;

    private void Awake()
    {
        GameObject.FindGameObjectWithTag("GameController").GetComponent<ISubject>().RegisterObserver(this);
    }

    public override void UpdateData(float currentTemp, float maxTemp, int treeCount, int co2Count)
    {
        if (currentTemp >= maxTemp)
        {
            Time.timeScale = 0;

            gameWinUI.SetActive(true);
        }
        else if (currentTemp == 0)
        {
            Time.timeScale = 0;

            gameLossUI.SetActive(true);
        }
    }
}
