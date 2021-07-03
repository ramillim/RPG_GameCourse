using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlippyBoxMovingBlock : MonoBehaviour
{
    Rigidbody2D _rigidBody;
    [SerializeField] float moveSpeed = 2.5f;

    void Awake()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        Vector2 movement = Vector2.left * (moveSpeed * Time.deltaTime);
        _rigidBody.position += movement;
        if (_rigidBody.position.x < -15f)
            _rigidBody.position += new Vector2(30f, 0);
    }
}
