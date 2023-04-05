using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleTargetTree : TreeTemplate
{
    [SerializeField]List<GameObject> validTargets = new List<GameObject>();
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
        GameObject tempCo2 = validTargets[0];
        gameStateTracker.UpdateCo2Count(-1);
        Destroy(tempCo2);
    }

    protected override bool CheckForCo2()
    {
        return validTargets.Count >= 1;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("AAAAAAAAA");
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
