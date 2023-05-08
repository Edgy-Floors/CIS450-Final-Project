using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigEmission : MonoBehaviour, Emission
{
    public Transform[] waypoints;
    private int currentWaypointIndex = 0;

    public float cloudSpeed = 3.0f;
    public GameStateTracker gst;
    public StateChanger sc;

    ObjectPooler objectPooler;

    private void Start()
    {
        gst = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameStateTracker>();
        sc = GameObject.FindGameObjectWithTag("GameController").GetComponent<StateChanger>();
        waypoints = WaypointManager.Instance.waypoints;
        objectPooler = ObjectPooler.uniqueInstance;
    }

    public void move()
    {
        Vector2 targetPosition = waypoints[currentWaypointIndex].position;
        transform.position = Vector2.MoveTowards(transform.position, targetPosition, cloudSpeed * Time.deltaTime);
        if(Vector2.Distance(transform.position, targetPosition) < 0.1f)
        {
            currentWaypointIndex++;
        }
    }

    private void Update()
    {
        if(currentWaypointIndex < waypoints.Length)
        {
            move();
        } else
        {
            gst.UpdateCo2Count(-2);
            objectPooler.ReturnObjectToPool("BigEnemy", gameObject);
        }
    }
}
