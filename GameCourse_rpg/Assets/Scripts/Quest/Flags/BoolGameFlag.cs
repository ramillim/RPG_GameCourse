using System;
using UnityEngine;

[CreateAssetMenu(menuName = "GamedFlag/Bool")]
public class BoolGameFlag : GameFlag <bool>
{
    //public static event Action AnyChanged;
    protected override void SetFromData(string value)
    {
        if (Boolean.TryParse(value, out var boolValue))
            Set(boolValue);
    }
}