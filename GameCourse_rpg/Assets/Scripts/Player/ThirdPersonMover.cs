using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonMover : MonoBehaviour
{
    [SerializeField] private float _turnspeed = 1000f;
    [SerializeField] private float moveSpeed = 5f;
    private Rigidbody rb;

    private void Update()
    {
        var mouseMovement = Input.GetAxis("Mouse X");
        transform.Rotate(0, mouseMovement* Time.deltaTime * _turnspeed, 0);
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        var velocity = new Vector3(horizontal, 0, vertical);
        velocity *= moveSpeed * Time.fixedDeltaTime;
        Vector3 offset = transform.rotation * velocity;
        rb.MovePosition(transform.position + offset);
    }
}
