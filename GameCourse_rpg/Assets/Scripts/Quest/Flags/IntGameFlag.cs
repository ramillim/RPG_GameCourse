using UnityEngine;

[CreateAssetMenu(menuName = "GamedFlag/Int")]
public class IntGameFlag : GameFlag<int>
{
    public void Modify(int value)
    {
        Set(Value + value);
        //AnyChanged?.Invoke();
        SendChange();
    }

    protected override void SetFromData(string value)
    {
        if(int.TryParse(value , out var intvalue))
            Set(intvalue);
    }
}