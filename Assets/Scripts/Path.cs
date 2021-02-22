using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Path : MonoBehaviour
{
    [SerializeField] private List<Transform> waypoints;

    public List<Transform> Waypoints => waypoints;

    public bool IsEmpty()
    {
        return waypoints == null || waypoints.Count == 0;
    }
}
