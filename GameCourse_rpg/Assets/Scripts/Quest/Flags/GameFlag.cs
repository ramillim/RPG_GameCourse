﻿using System;
using UnityEngine;

public abstract class GameFlag : ScriptableObject
{
    public event Action Changed;
    protected void SendChange() => Changed?.Invoke();
}

public abstract class GameFlag<T> : GameFlag
{
    public T Value { get; protected set; }

    void OnEnable() => Value = default;
    void OnDisable() => Value = default;
}