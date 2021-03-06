using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlippyBoxMovingBlock : MonoBehaviour, IRestart
{
    Rigidbody2D _rigidBody;
    float moveSpeed => FlippyBoxMiniGamePanel.Instance.currentSettings.MovingBoxSpeed;
    Vector3 _startingPosition;

    void Awake()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
        _startingPosition = transform.position;
    }

    void FixedUpdate()
    {
        Vector2 movement = Vector2.left * (moveSpeed * Time.deltaTime);
        _rigidBody.position += movement;
        if (transform.localPosition.x < -15f)
            _rigidBody.position += new Vector2(30f, 0);
    }
    public void Restart()
    {
        transform.position = _startingPosition;
    }
}
