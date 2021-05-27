using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameFlagTriggerArea : MonoBehaviour
{
    [SerializeField] GameFlag _gameFlag;

    void OnTriggerEnter(Collider other)
    {
        _gameFlag.Set(true);
    }
}
