using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class MovingBlock : MonoBehaviour
{
    //Speed is getting set to zero. needs to be completely redone

    private Rigidbody rb;


    [SerializeField]
    private float speed;

    [SerializeField]
    private Vector3 direction;

    private Vector3 originalPosition;
    private Vector3 finalPosition;

    [SerializeField]
    private int distanceUntilLoopBack;

    [SerializeField]
    private bool pauseAtDestination;


    [SerializeField]
    [Range(.1f, 5f)]
    private float delayTime;

    private enum MovementState
    {
        forward,
        backward,
        endReached,
        startReached,
        paused,
    }

    private MovementState movementState;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.useGravity = false;
        rb.isKinematic = true;
        originalPosition = transform.position;
        finalPosition = transform.position + direction * distanceUntilLoopBack;        
    }

    private void FixedUpdate()
    {
        Movement();
    }

    private void Movement()
    {
        switch(movementState)
        {
            case MovementState.forward:
                rb.MovePosition(transform.position + direction * speed * Time.deltaTime);
                break;
            case MovementState.backward:
                rb.MovePosition(transform.position + direction * -speed * Time.deltaTime);
                break;
            case MovementState.endReached:
                if(pauseAtDestination)
                {
                    StartCoroutine(Paused(delayTime, MovementState.backward));
                    movementState = MovementState.paused;
                }
                else
                {
                    movementState = MovementState.backward;
                }
                
                break;
            case MovementState.startReached:
                if(pauseAtDestination)
                {
                    StartCoroutine(Paused(delayTime, MovementState.forward));
                    movementState = MovementState.paused;
                }

                else
                {
                    movementState = MovementState.forward;
                }
                break;
            case MovementState.paused:
                break;
            default:
                print("Idk what happened tbh");
                break;

        }
        ArrivalCheck(); 
    }

    private void ArrivalCheck()
    {
        if(movementState == MovementState.forward)
        {
            if(InRangeOfDestination(transform.position, finalPosition))
            {
                movementState = MovementState.endReached;
            }
        }
        else if(movementState == MovementState.backward)
        {
            if(InRangeOfDestination(transform.position, originalPosition))
            {
                movementState = MovementState.startReached;
            }
        }
    }


    private IEnumerator Paused(float time, MovementState nextState)
    {
        yield return new WaitForSeconds(time);
        movementState = nextState;
    }

    private bool InRangeOfDestination(Vector3 point1, Vector3 point2)
    {
        if(Vector3.Distance(point1, point2) < .2f)
        {
            return true;
        }
        else
        {
            return false;
        }
    }


   

}
