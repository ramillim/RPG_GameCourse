using UnityEngine;

[CreateAssetMenu(menuName = "GamedFlag/Int")]
public class IntGameFlag : GameFlag<int>
{
    public void Modify(int value)
    {
        Value += value;
        //AnyChanged?.Invoke();
        SendChange();
    }
}