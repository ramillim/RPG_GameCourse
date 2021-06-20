using UnityEngine;
public class MetIntFlagCondition : MonoBehaviour, IMet
{
    [SerializeField] IntGameFlag _requiredFlag;
    [SerializeField] int _requiredValue = 2;

    public bool Met() => _requiredFlag.Value >= _requiredValue;
}