using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutOfBounds : MonoBehaviour
{
    private Vector3 startLocation;
    private bool fallOff = false;


    // Start is called before the first frame update
    void Start()
    {
        startLocation = transform.position;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("OutOfBounds"))
        {
            fallOff = true;

        }
    }


    private void Update()
    {
        if (fallOff)
        {
            transform.position = Vector3.Lerp(transform.position, startLocation, .05f);
            GetComponent<SphereCollider>().enabled = false;
            GetComponent<Rigidbody>().isKinematic = true;
            GetComponent<MovePlayer>().enabled = false;
            StartCoroutine(Reset());
        }
        else
        {
            GetComponent<SphereCollider>().enabled = true;
            GetComponent<Rigidbody>().isKinematic = false;
            
        }
        if(Vector3.Distance(startLocation, transform.position) < .5f)
        {
            fallOff = false;
        }

    }

    private IEnumerator Reset()
    {
        yield return new WaitForSeconds(1f);
        GetComponent<MovePlayer>().enabled = true;
    }

    
}
