using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Player : MonoBehaviour
{
    [SerializeField] private float speed;

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        var position = transform.position;
        var deltaX = Input.GetAxis("Horizontal") * Time.deltaTime * speed;
        var newXPos = position.x + deltaX;
        var deltaY = Input.GetAxis("Vertical") * Time.deltaTime * speed;
        var newYPos = position.y + deltaY;

        transform.position = new Vector2(newXPos, newYPos);
    }
}
