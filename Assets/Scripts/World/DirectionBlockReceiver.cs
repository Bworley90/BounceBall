using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectionBlockReceiver : MonoBehaviour
{
    public int Number;
    private Rigidbody rb;

    [SerializeField]
    private float speed;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }


    private void OnEnable()
    {
        DirectionBlock.BlockDirection += Movement;
    }

    private void OnDisable()
    {
        DirectionBlock.BlockDirection -= Movement;

    }

    private void Movement(Vector3 direction, int blockNumber)
    {
        if(blockNumber == Number)
        {
            rb.MovePosition(transform.position + direction * speed * Time.deltaTime);
        }
        
    }
}
