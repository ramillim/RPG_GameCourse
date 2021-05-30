using UnityEngine;

public class GameFlagTriggerAreaForIntFlag : MonoBehaviour
{
    [SerializeField] int amount;
    [SerializeField] IntGameFlag _intGameFlag;

    void OnTriggerEnter(Collider other)
    {
        _intGameFlag.Modify(amount);
    }
}