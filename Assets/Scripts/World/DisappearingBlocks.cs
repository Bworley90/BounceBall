using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
[RequireComponent(typeof(MeshRenderer))]

public class DisappearingBlocks : MonoBehaviour
{
    private BoxCollider bc;
    private MeshRenderer mr;

    [SerializeField]
    private float timeActive;

    [SerializeField]
    private float delayStartTime;

    private void Start()
    {
        bc = GetComponent<BoxCollider>();
        mr = GetComponent<MeshRenderer>();
        StartCoroutine(StartOffset(delayStartTime));
    }

    private IEnumerator StartOffset(float delayTime)
    {
        yield return new WaitForSeconds(delayTime);
        StartCoroutine(EnableDisable(timeActive));
    }

    private IEnumerator EnableDisable(float time)
    {
        yield return new WaitForSeconds(time);
        if(bc.enabled == false && mr.enabled == false)
        {
            bc.enabled = true;
            mr.enabled = true;
            StartCoroutine(EnableDisable(timeActive));
        }
        else
        {
            mr.enabled = false;
            bc.enabled = false;
            StartCoroutine(EnableDisable(timeActive));
        }
    }


}
