using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadingBlock : MonoBehaviour
{
    [SerializeField]
    private float timeUntilFade;

    [SerializeField]
    private float respawnTime;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.gameObject.CompareTag("Player"))
        {
            //start fading
        }
    }

}
