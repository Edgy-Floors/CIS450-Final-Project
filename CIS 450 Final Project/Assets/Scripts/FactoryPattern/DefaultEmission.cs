using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultEmission : MonoBehaviour, Emission
{
    [Tooltip("Speed for the default emission")]
    public float cloudSpeed = 5.0f;

    [Tooltip("Reference to the gameStateTracker")]
    public GameStateTracker gst;

    public Transform[] waypoints;
    private int currentWaypointIndex = 0;

    private void Start()
    {
        waypoints = WaypointManager.Instance.waypoints;
    }

    private void Awake()
    {
        gst = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameStateTracker>();
        //gst.UpdateCo2Count(1);
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
        }
    }

    private void OnEnable()
    {
        gst.UpdateCo2Count(1);
    }

    private void OnDisable()
    {
        gst.UpdateCo2Count(-1);
    }
}
