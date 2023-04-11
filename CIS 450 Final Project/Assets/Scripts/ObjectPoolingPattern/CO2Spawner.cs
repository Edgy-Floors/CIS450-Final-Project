using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CO2Spawner : MonoBehaviour
{
    ObjectPooler objectPooler;
    [SerializeField] GameStateTracker gameStateTracker;
    [SerializeField] float spawnTimer;
    [SerializeField] Vector2 spawnPos;

    private void Start()
    {
        objectPooler = ObjectPooler.uniqueInstance;

        StartSpawning();
    }

    public void StartSpawning()
    {
        StartCoroutine(SpawnCO2());
    }

    public void StopSpawning()
    {
        StopAllCoroutines();
    }

    IEnumerator SpawnCO2()
    {
        while (true)
        {
            objectPooler.SpawnFromPool("Enemy", spawnPos, Quaternion.identity);

            gameStateTracker.UpdateCo2Count(1);

            yield return new WaitForSeconds(spawnTimer);
        }
    }
}
