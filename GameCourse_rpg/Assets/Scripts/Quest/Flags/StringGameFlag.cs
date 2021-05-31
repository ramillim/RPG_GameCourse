using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StringGameFlag : GameFlag<string>
{
    public void Modify(string value)
    {
        Value = value;
        SendChange();
    }
}
