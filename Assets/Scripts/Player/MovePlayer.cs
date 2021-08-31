using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[RequireComponent(typeof(Rigidbody))]

public class MovePlayer : MonoBehaviour
{
    
    private Camera cam;
    private Rigidbody rb;
    private LineRenderer lr;

    private Text powerText;

    [Range(0, 200)]
    [Tooltip("Force added to player when clicked")]
    public int pushForce;

    
    [Tooltip("The maximum amount of pull distance. Default is 4")]
    public float maxPullDistance;


    public enum PlayerState
    {
        moving,
        aiming
    }

    public PlayerState playerState;


    private void OnEnable()
    {
        //CameraFollow.Zooming += AdjustPullDistance;
    }

    private void OnDisable()
    {
        //CameraFollow.Zooming -= AdjustPullDistance;
    }

    private void Start()
    {
        cam = Camera.main;
        rb = GetComponent<Rigidbody>();
        lr = GetComponent<LineRenderer>();
        try
        {
            powerText = GameObject.FindGameObjectWithTag("PowerMeter").GetComponent<Text>();
        }
        catch
        {
            Debug.Log("You are missing a Power Meter prefab");
        }
    }

    private void Update()
    {
        StateChange();
        PullLine();
        AddForce();
        PowerMeter();
        //maxPullDistance = Mathf.Clamp(maxPullDistance, 4, 16);
    }

    private Vector3 MouseLocation()
    {
        Vector3 mouseLocation = Input.mousePosition;
        mouseLocation.z = -cam.transform.position.z;

        Vector3 temp = Camera.main.ScreenToWorldPoint(mouseLocation);

        return temp;
    }


    private void StateChange()
    {
        // If the ball is moving
        if(rb.velocity.magnitude > 0 || rb.velocity.magnitude < 0)
        {
            playerState = PlayerState.moving;
        }
        else
        {
            playerState = PlayerState.aiming;
        }
    }

    private void PullLine()
    {
        new Vector3(transform.position.x, transform.position.y, transform.position.z - 2);
        lr.SetPosition(0, new Vector3(transform.position.x, transform.position.y, transform.position.z - 2));
        //lr.SetPosition(1, MouseLocation());
        lr.SetPosition(1, new Vector3(MouseLocation().x, MouseLocation().y, MouseLocation().z + 1));
        if(playerState == PlayerState.aiming)
        {
            lr.enabled = true;
        }
        else if(playerState == PlayerState.moving)
        {
            lr.enabled = false;
        }
    }

    private void AddForce()
    {
        if(playerState == PlayerState.aiming)
        {
            if(Input.GetMouseButtonDown(0))
            {
                float distance = Vector3.Distance(MouseLocation(), transform.position);
                Vector3 direction = transform.position - MouseLocation();
                direction.Normalize();
                float maxDistance = Mathf.Clamp(distance, 0, maxPullDistance);
                rb.AddForce(direction * maxDistance * pushForce);
                //rb.AddForce(direction * ((maxDistance/maxPullDistance * 3.5f)) * pushForce);
               
            }
        }
    }

    private void PowerMeter()
    {
        float distance = Vector3.Distance(MouseLocation(), transform.position);
        float maxDistance = Mathf.Clamp(distance, 0, maxPullDistance);

        if(playerState == PlayerState.aiming)
        {
            powerText.text = Mathf.RoundToInt(maxDistance / maxPullDistance * 100).ToString();
        }
        else
        {
            powerText.text = "";
        }
        
    }


    private void AdjustPullDistance(float direction)
    {
        float scaleOfAdjustment = .35f;
        maxPullDistance += direction * scaleOfAdjustment;
    }

}
