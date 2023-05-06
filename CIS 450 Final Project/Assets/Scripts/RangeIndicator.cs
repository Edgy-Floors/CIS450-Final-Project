using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeIndicator : MonoBehaviour
{
    SpriteRenderer mainIndicatorSR;
    SpriteRenderer secondaryIndicatorSR;
    Transform secondaryTransform;
    bool isActive = false;

    private void Awake()
    {
        mainIndicatorSR = GetComponent<SpriteRenderer>();
        secondaryTransform = transform.GetChild(0);
        secondaryIndicatorSR = secondaryTransform.gameObject.GetComponent<SpriteRenderer>();
    }

    private void FixedUpdate()
    {
        if (isActive)
        {
            transform.position = (Vector2) Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
    }

    public void ActivateIndicator(float range)
    {
        isActive = true;

        mainIndicatorSR.enabled = true;
        transform.localScale = new Vector2(range * 2, range * 2);
    }

    public void ActivateIndicator(float range, float secondaryRange)
    {
        isActive = true;

        mainIndicatorSR.enabled = true;
        transform.localScale = new Vector2(range * 2, range * 2);

        secondaryIndicatorSR.enabled = true;
        float secondaryScale = secondaryRange / range;
        secondaryTransform.localScale = new Vector2(secondaryScale, secondaryScale);
    }

    public void DeactivateIndicator()
    {
        isActive = false;

        mainIndicatorSR.enabled = false;
        secondaryIndicatorSR.enabled = false;
    }
}
