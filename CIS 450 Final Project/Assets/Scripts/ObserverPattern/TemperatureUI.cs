using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TemperatureUI : IObserver
{
    [SerializeField] Image thermometerSlider;

    private void Awake()
    {
        GameObject.FindGameObjectWithTag("GameController").GetComponent<ISubject>().RegisterObserver(this);
    }

    public override void UpdateData(float currentTemp, float maxTemp, int treeCount, int co2Count)
    {
        thermometerSlider.fillAmount = currentTemp / maxTemp;
    }
}
