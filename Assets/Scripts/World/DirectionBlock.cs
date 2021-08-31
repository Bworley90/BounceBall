using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class DirectionBlock : MonoBehaviour
{
    public static Action<Vector3, int> BlockDirection;

    public int blockNumber;

    private enum Direction
    { 
        Up,
        Down,
        Left,
        Right  
    };

    [SerializeField]
    private Direction direction;

    private Vector3 currentDirection;


    private void OnCollisionStay(Collision other)
    {
        BlockDirection.Invoke(currentDirection, blockNumber);
    }

    private void Start()
    {
        switch(direction)
        {
            case Direction.Up:
                currentDirection = Vector3.up;
                break;
            case Direction.Down:
                currentDirection = Vector3.down;
                break;
            case Direction.Left:
                currentDirection = Vector3.left;
                break;
            case Direction.Right:
                currentDirection = Vector3.right;
                break;
            default:
                Debug.LogError(transform.name + " Does not have a direction selected");
                break;
        }
    }




}
