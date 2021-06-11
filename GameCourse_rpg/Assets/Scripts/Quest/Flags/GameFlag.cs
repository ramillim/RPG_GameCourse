using System;
using UnityEngine;

public abstract class GameFlag : ScriptableObject
{
    public GameFlagData GameFlagData { get; private set; }
    public event Action Changed;
    protected void SendChange() => Changed?.Invoke();

    public void Bind(GameFlagData gameFlagData)
    {
        GameFlagData = gameFlagData;
        SetFromData(GameFlagData.Value);
    }

    protected abstract void SetFromData(string value);
}

public abstract class GameFlag<T> : GameFlag
{
    public T Value { get; private set; }

    void OnEnable() => Value = default;
    void OnDisable() => Value = default;

    public void Set(T value)
    {
        Value = value;
        GameFlagData.Value = Value?.ToString();
        SendChange();
    }
    
}
[Serializable]
public class GameFlagData
{
    public string Name;
    public string Value;
}