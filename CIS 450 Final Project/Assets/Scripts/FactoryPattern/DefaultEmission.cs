using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultEmission : MonoBehaviour, Emission
{
    [Tooltip("Speed for the default emission")]
    public float cloudSpeed = 5.0f;

    [Tooltip("Reference to the gameStateTracker")]
    public GameStateTracker gst;

    private void Start()
    {
        
    }

    private void Awake()
    {
        gst = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameStateTracker>();
        //gst.UpdateCo2Count(1);
    }

    public void move(float speed)
    {

    }

    private void Update()
    {

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
