using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigEmission : MonoBehaviour, Emission
{
    public Transform[] waypoints;
    private int currentWaypointIndex = 0;

    public float cloudSpeed = 3.0f;
    public GameStateTracker gst;

    ObjectPooler objectPooler;

    private void Start()
    {
        waypoints = WaypointManager.Instance.bigWaypoints;
        objectPooler = ObjectPooler.uniqueInstance;
    }

    public void move()
    {

        Vector2 targetPosition = waypoints[currentWaypointIndex].position;
        transform.position = Vector2.MoveTowards(transform.position, targetPosition, cloudSpeed * Time.deltaTime);
    }
}
