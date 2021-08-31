using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class FinishBlock : MonoBehaviour
{
    private GameObject player;
    private Rigidbody rb;
    private GameObject endOfLevelUI;
    private bool didPlayerFinishLevel;


    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        rb = player.GetComponent<Rigidbody>();
        endOfLevelUI = GameObject.FindGameObjectWithTag("EndOfLevelUI");
    }

    private void OnTriggerStay(Collider other)
    {
        // If the player isn't moving
        if(rb.velocity.magnitude == 0)
        {
            endOfLevelUI.GetComponent<Animator>().SetTrigger("completedLevel");
            didPlayerFinishLevel = true;
        }
    }

    private void Update()
    {
        if (didPlayerFinishLevel)
        {
            player.GetComponent<MovePlayer>().enabled = false;
        }
    }


}
