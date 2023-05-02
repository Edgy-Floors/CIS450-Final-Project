using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrettyTree : TreeTemplate
{
    [SerializeField] List<GameObject> validTargets = new List<GameObject>();
    CircleCollider2D attackRange;
    ObjectPooler objectPooler;

    private void Awake()
    {
        objectPooler = ObjectPooler.uniqueInstance;

        attackRange = GetComponent<CircleCollider2D>();
        attackRange.radius = absorbtionRange;

        gameStateTracker = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameStateTracker>();
        gameStateTracker.UpdateTreeCount(1);

        gameFacade = GameObject.Find("GameFacade").GetComponent<GameFacade>();

        StartCoroutine(Absorb());
    }

    protected override void AbsorbCo2()
    {
        GameObject tempCo2 = validTargets[0];
        gameStateTracker.UpdateCo2Count(-1);
        objectPooler.ReturnObjectToPool("Enemy", tempCo2);
    }

    protected override bool CheckForCo2()
    {
        return validTargets.Count >= 1;
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
