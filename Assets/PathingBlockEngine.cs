using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PathingBlockEngine : MonoBehaviour
{
    public static Action<Transform[], float, float> Pathing;

    [SerializeField]
    private Transform[] pathPoints;

    [SerializeField]
    private float timeToReachPoint;

    [SerializeField]
    private float waitTime;


    private void Start()
    {
        Pathing.Invoke(pathPoints, timeToReachPoint, waitTime);
    }

}
