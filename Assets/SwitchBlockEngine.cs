using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchBlockEngine : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> switchBlocks = new List<GameObject>();

    private int index = 0;


    [SerializeField]
    private string inputButtonString = "Jump";


    private void Update()
    {
        SwitchBlock();       
    }


    private void SwitchBlock()
    {
        if (Input.GetButtonDown(inputButtonString))
        {
            if (index == switchBlocks.Capacity - 1)
            {
                index = 0;
            }
            else
            {
                index++;
            }
        }
        if(switchBlocks[index] == null)
        {
            Debug.Log("Missing blocks in the block engine list. \t Disabling Object: " + transform.name);
            gameObject.SetActive(false);
        }
        else
        {
            for (int i = 0; i < switchBlocks.Capacity; i++)
            {
                if (i == index)
                {
                    switchBlocks[i].SetActive(true);
                }
                else
                {
                    switchBlocks[i].SetActive(false);
                }
            }
        }
    }
        
}
