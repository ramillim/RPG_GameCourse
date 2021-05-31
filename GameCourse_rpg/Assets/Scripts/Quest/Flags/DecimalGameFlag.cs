using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DecimalGameFlag : GameFlag<decimal>
{
    public void Modify(decimal value)
    {
        Value += value;
        SendChange();
    }
}
