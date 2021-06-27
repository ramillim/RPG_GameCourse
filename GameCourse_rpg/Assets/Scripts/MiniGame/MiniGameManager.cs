using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniGameManager : MonoBehaviour
{
    Action _completeInspection;
    public static MiniGameManager Instance { get; private set; }

    void Awake() => Instance = this;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Y))
        {
            _completeInspection?.Invoke();
            _completeInspection = null;
        }
    }

    public void StartMiniGame(Action completeInspection)
    {
        _completeInspection = completeInspection;
    }
}
