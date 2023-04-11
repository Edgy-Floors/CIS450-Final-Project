using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
    public List<Pool> poolList;
    public Dictionary<string, Queue<GameObject>> poolDictionary;

    public static ObjectPooler uniqueInstance;

    /// <summary>
    /// Sets the singleton instance of this class and initializes the pools
    /// </summary>
    private void Awake()
    {
        if (uniqueInstance == null)
        {
            uniqueInstance = this;
        }

        poolDictionary = new Dictionary<string, Queue<GameObject>>();
        FillPools();
    }

    /// <summary>
    /// Called on Awake to use poolList to generate pools of GameObjects
    /// </summary>
    private void FillPools()
    {
        foreach (Pool pool in poolList)
        {
            Queue<GameObject> newObjectPool = new Queue<GameObject>();

            for (int i = 0; i < pool.poolSize; ++i)
            {
                GameObject tempObject = Instantiate(pool.prefab);

                tempObject.SetActive(false);

                newObjectPool.Enqueue(tempObject);
            }

            poolDictionary.Add(pool.poolTag, newObjectPool);
        }
    }

    /// <summary>
    /// Called to spawn an object from a pool at a certain location
    /// </summary>
    /// <param name="tag">The pool being accessed</param>
    /// <param name="position">Where the object will spawn</param>
    /// <param name="rotation">The object's rotation upon spawning</param>
    /// <returns>The GameObject that was spawned</returns>
    public GameObject SpawnFromPool(string tag, Vector3 position, Quaternion rotation)
    {
        if (poolDictionary.ContainsKey(tag) == false || poolDictionary[tag].Count == 0)
        {
            return null;
        }

        GameObject objectToSpawn = poolDictionary[tag].Dequeue();

        objectToSpawn.SetActive(true);

        objectToSpawn.transform.position = position;
        objectToSpawn.transform.rotation = rotation;

        poolDictionary[tag].Enqueue(objectToSpawn);

        return objectToSpawn;
    }

    /// <summary>
    /// Called to return a GameObject to a pool
    /// </summary>
    /// <param name="tag">The pool being returned to</param>
    /// <param name="objectToReturn">The GameObject that's returning</param>
    public void ReturnObjectToPool(string tag, GameObject objectToReturn)
    {
        objectToReturn.SetActive(false);
    }
}
