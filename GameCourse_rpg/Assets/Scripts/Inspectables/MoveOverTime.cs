using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveOverTime : MonoBehaviour
{
    [SerializeField] float _duration;
    [SerializeField] Vector3 _magnitude = Vector3.down;
    [SerializeField] AnimationCurve _curve = AnimationCurve.Linear(0f,0f, 1f,1f);
    
    Vector3 _startingPos;
    Vector3 _endingPos;
    float _elapsed;

    void OnEnable()
    {
        _elapsed = 0f;
        _endingPos = _startingPos + _magnitude;
    }
    void Awake()
    {
        _startingPos = transform.position;
    }

    void OnDisable() => transform.position = _startingPos;

    void Update()
    {
        _elapsed += Time.deltaTime;
        float pctElapsed = _elapsed / _duration;
        float pctOnCurve = _curve.Evaluate(pctElapsed);
        transform.position = Vector3.Lerp(_startingPos, _endingPos, pctOnCurve);
    }
}
