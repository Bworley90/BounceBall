using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class NoPlayerMovementOverUI : MonoBehaviour
{

    private void Update()
    {
        IsMouseOverUI();
    }
    public void IsMouseOverUI()
    {

        if (EventSystem.current.IsPointerOverGameObject())
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<MovePlayer>().enabled = false;
        }
        else
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<MovePlayer>().enabled = true;
        }

    }

}
