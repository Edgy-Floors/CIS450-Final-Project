using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurstTree : TreeTemplate
{
    List<GameObject> validTargets = new List<GameObject>();
    CircleCollider2D attackRange;

    private void Awake()
    {
        attackRange = GetComponent<CircleCollider2D>();
        attackRange.radius = absorbtionRange;

        gameStateTracker = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameStateTracker>();
        gameStateTracker.UpdateTreeCount(1);

        StartCoroutine(Absorb());
    }

    protected override void AbsorbCo2()
    {
        GameObject tempCo2;

        for (int i = 0; i < 3; ++i)
        {
            tempCo2 = validTargets[0];
            gameStateTracker.UpdateCo2Count(-1);
            Destroy(tempCo2);
        }
    }

    protected override bool CheckForCo2()
    {
        return validTargets.Count >= 3;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            validTargets.Add(collision.gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && validTargets.Contains(collision.gameObject))
        {
            validTargets.Remove(collision.gameObject);
        }
    }
}
