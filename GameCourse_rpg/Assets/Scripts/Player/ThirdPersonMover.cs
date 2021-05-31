using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonMover : MonoBehaviour
{
    [SerializeField] private float _turnspeed = 1000f;
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private Rigidbody rb;
    private Animator _anim;
    private float _mouseMovement;

    private void Start()
    {
      if (rb == null) 
      {
          rb = GetComponent<Rigidbody>();
      }

      _anim = GetComponent<Animator>();
    }

    private void Update()
    {
        _mouseMovement += Input.GetAxis("Mouse X");
    }

    private void FixedUpdate()
    {
        if(ToggleablePanel.isVisible == false)
            transform.Rotate(0, _mouseMovement* Time.deltaTime * _turnspeed, 0);
        _mouseMovement = 0f;
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        if (Input.GetKey(KeyCode.LeftShift) && vertical <= 1f)
            vertical *= 2f;

        
        var velocity = new Vector3(horizontal, 0, vertical);
        velocity *= moveSpeed * Time.fixedDeltaTime;
        Vector3 offset = transform.rotation * velocity;
        rb.MovePosition(transform.position + offset);
        _anim.SetFloat("Horizontal", horizontal, 0.1f, Time.deltaTime);
        _anim.SetFloat("Vertical", vertical, 0.1f, Time.deltaTime);
    }
}
