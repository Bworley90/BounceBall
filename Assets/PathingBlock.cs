using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class PathingBlock : MonoBehaviour
{
    private float _speed;

    private float _time;

    private float _distance;

    private float _waitTimeAtPoint;

    private Transform[] path;

    private int index;

    [SerializeField]
    private int startIndex;

    private Rigidbody rb;

    private enum State
    {
        calculateSpeed,
        moving,
        waiting
    }


    private State state = State.calculateSpeed;

    private void Start()
    {
        index = startIndex;
        SetupRigidBody();
    }

    private void OnEnable()
    {
        PathingBlockEngine.Pathing += Setup;
        

    }

    private void OnDisable()
    {
        PathingBlockEngine.Pathing -= Setup;

    }

    private void Setup(Transform[] points, float timeToReachPoint, float waitTime)
    {
        path = points;
        _time= timeToReachPoint;
        _waitTimeAtPoint = waitTime;
        transform.position = (path[startIndex].position);
    }

    private void FixedUpdate()
    {
        if(state == State.moving)
        {
            Movement();
        }
        else if(state == State.calculateSpeed)
        {
            SpeedCalcuation();
        }
    }

    private void Movement()
    {
        Vector3 direction = Vector3.MoveTowards(transform.position, path[index].position, _speed);
        rb.MovePosition(direction);
        if(Arrived())
        {
            StartCoroutine(Wait());
            state = State.waiting;
        }
        

    }

    private void SpeedCalcuation()
    {
        _distance = Vector3.Distance(transform.position, path[index].position);
        _speed = _distance / _time * Time.fixedDeltaTime;
        state = State.moving;
    }

       

    private void SetupRigidBody()
    {
        rb = GetComponent<Rigidbody>();
        rb.isKinematic = true;
        rb.useGravity = false;      
    }

    private bool Arrived()
    {
        if(Vector3.Distance(transform.position, path[index].position) == 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private IEnumerator Wait()
    {
        yield return new WaitForSeconds(_waitTimeAtPoint);
        if(index == path.Length - 1)
        {
            index = 0;
        }
        else
        {
            index++;
        }
        state = State.calculateSpeed;
    }


}
