using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CameraFollow : MonoBehaviour
{
    public static Action<float> Zooming;

    private GameObject player;
    public int cameraOffsetZ = 0;
    [Range(0, 5)]
    public float cameraOffsetY = 0;
    [Range(-5, 5)]
    public float cameraOffsetX = 0;
    [Tooltip("The speed the camera follow the player")]
    [Range(.01f, 1)]
    public float smoothingFactor;
    private Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        offset = new Vector3(cameraOffsetX, cameraOffsetY, -cameraOffsetZ);
        Vector3 desiredPosition = player.transform.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothingFactor);
        transform.position = smoothedPosition;
        cameraOffsetZ = Mathf.Clamp(cameraOffsetZ, 10, 30);
    }

    private void Update()
    {
        if(Input.mouseScrollDelta.y > Vector2.zero.y)
        {
            //Zooming.Invoke(-1);
            cameraOffsetZ -= 1;
        }
        else if(Input.mouseScrollDelta.y < Vector2.zero.y)
        {
            //Zooming.Invoke(1);
            cameraOffsetZ += 1;
        }
    }



}
