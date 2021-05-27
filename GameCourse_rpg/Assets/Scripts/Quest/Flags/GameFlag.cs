using System;
using UnityEngine;

[CreateAssetMenu(menuName = "Bool Game Flag")]
public class GameFlag : ScriptableObject
{
    public bool Value { get; private set; }
    //public static event Action AnyChanged;
    public event Action Changed;

    void OnEnable() => Value = default;

    void OnDisable() => Value = default;

    public void Set(bool value)
    {
        Value = value;
        //AnyChanged?.Invoke();
        Changed.Invoke();
    }

    
}
