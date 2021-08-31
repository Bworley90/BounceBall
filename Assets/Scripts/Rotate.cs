using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    private Rigidbody rb;

    [SerializeField]
    private float speed;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void FixedUpdate()
    {
        Quaternion rotation = Quaternion.Euler(0, 0, speed * Time.fixedDeltaTime);
        rb.MoveRotation(rb.rotation * rotation);
    }
}
