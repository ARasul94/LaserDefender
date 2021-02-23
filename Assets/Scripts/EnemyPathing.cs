using System;
using System.Collections;
using System.Collections.Generic;
using ScriptableObjects;
using UnityEngine;
using UnityEngine.Events;

public class EnemyPathing : MonoBehaviour
{
    private float _moveSpeed;
    private Path _path;
    private bool _isLast;
    private int _waypointIndex = 0;

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        if (!_path.IsEmpty() && _path.Waypoints.Count > _waypointIndex)
        {
            var targetPosition = _path.Waypoints[_waypointIndex].position;
            var movementInThisFrame = _moveSpeed * Time.deltaTime;
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
            if (_isLast)
                Destroy(_path.gameObject);
            Destroy(gameObject);
        }
    }

    public void SetupEnemyParameters(Path path, float speed, bool isLast)
    {
        _path = path;
        _moveSpeed = speed;
        _isLast = isLast;
        
        if (!_path.IsEmpty())
            transform.position = _path.Waypoints[_waypointIndex].position;
    }
}
