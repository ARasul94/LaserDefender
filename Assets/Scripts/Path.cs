using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Path : MonoBehaviour
{
    private List<Transform> _waypoints;
    public List<Transform> Waypoints => _waypoints;

    private void Awake()
    {
        _waypoints = new List<Transform>();
        foreach (Transform child in transform)
        {
            _waypoints.Add(child);
        }
    }

    public bool IsEmpty()
    {
        return _waypoints == null || _waypoints.Count == 0;
    }
}
