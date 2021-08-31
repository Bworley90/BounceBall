using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerMeter : MonoBehaviour
{
    public Vector3 offset;

    private GameObject player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

    }


    private void Update()
    {
        transform.position = player.transform.position + offset;
    }
}
