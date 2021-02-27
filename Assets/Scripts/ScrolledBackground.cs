using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshRenderer), typeof(MeshFilter))]
public class ScrolledBackground : MonoBehaviour
{
    [SerializeField] private float scrollYSpeed = 0.1f;
    [SerializeField] private float scrollXSpeed = 0.5f;

    private MeshRenderer _meshRenderer;
    private Material _material;
    private void Start()
    {
        _meshRenderer = GetComponent<MeshRenderer>();
        _material = _meshRenderer.material;
    }

    private void Update()
    {
        var xOffset = Input.GetAxis("Horizontal") * scrollXSpeed;
        var verticalInput = Input.GetAxis("Vertical");
        var yOffset = scrollYSpeed + (verticalInput > 0 ? verticalInput : 0) * scrollYSpeed;
        var offset = new Vector2(xOffset, yOffset);
        _material.mainTextureOffset += offset * Time.deltaTime;
    }
}
