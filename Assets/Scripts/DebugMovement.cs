using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class DebugMovement : MonoBehaviour
{
    public target[] movement;
    public float movementSpeed = 3.0f;
    public float waitingTime = 5.0f;

    public Vector2? currentTarget;
    public int index = 0;
    public bool waiting = false;
    public float waitTime = 0.0f;
    void Update()
    {
        if(waiting)
        {
            if (waitTime < waitingTime)
                waitTime += Time.deltaTime;
            else
                waiting = false;
        }
        else if (!currentTarget.HasValue)
        {
            if (index >= movement.Length)
                index = 0;

            switch (movement[index].direction)
            {
                case Enums.Direction.Up:
                    currentTarget = (Vector2)transform.position + (Vector2.up * movement[index].distance);
                    break;
                case Enums.Direction.Right:
                    currentTarget = (Vector2)transform.position + (Vector2.right * movement[index].distance);
                    break;
                case Enums.Direction.Down:
                    currentTarget = (Vector2)transform.position + (Vector2.down * movement[index].distance);
                    break;
                case Enums.Direction.Left:
                    currentTarget = (Vector2)transform.position + (Vector2.left * movement[index].distance);
                    break;
                case Enums.Direction.UpRight:
                    currentTarget = (Vector2)transform.position + (new Vector2(0.71f, 0.71f) * movement[index].distance);
                    break;
                case Enums.Direction.DownRight:
                    currentTarget = (Vector2)transform.position + (new Vector2(0.71f, -0.71f) * movement[index].distance);
                    break;
                case Enums.Direction.DownLeft:
                    currentTarget = (Vector2)transform.position + (new Vector2(-0.71f, -0.71f) * movement[index].distance);
                    break;
                case Enums.Direction.UpLeft:
                    currentTarget = (Vector2)transform.position + (new Vector2(-0.71f, 0.71f) * movement[index].distance);
                    break;
            }
        }
        else if (MoveToTarget(currentTarget.Value, 0.1f))
        {
            index++;
            currentTarget = null;
            waiting = true;
            waitTime = 0.0f;
        }
    }

    bool MoveToTarget(Vector3 target, float stopDistance)
    {
        if (Vector2.Distance(transform.position, target) < stopDistance) //Check distance before moving so you can instantly stop if you're close enough
        {
            return true;
        }

        transform.position = Vector2.MoveTowards(transform.position, target, movementSpeed * Time.deltaTime);

        return false;
    }
}

[System.Serializable]
public struct target
{
    public float distance;
    public Enums.Direction direction;
}




