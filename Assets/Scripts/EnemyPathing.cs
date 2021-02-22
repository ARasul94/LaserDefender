using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPathing : MonoBehaviour
{
    [SerializeField] private Path path;
    [SerializeField] private float moveSpeed;

    private int _waypointIndex = 0;

    private void Start()
    {
        if (!path.IsEmpty())
            transform.position = path.Waypoints[_waypointIndex].position;
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        if (!path.IsEmpty() && path.Waypoints.Count > _waypointIndex)
        {
            var targetPosition = path.Waypoints[_waypointIndex].position;
            var movementInThisFrame = moveSpeed * Time.deltaTime;
            transform.position = Vector2.MoveTowards(
                transform.position, 
                targetPosition, 
                movementInThisFrame);

            if (transform.position == targetPosition)
            {
                _waypointIndex++;
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
