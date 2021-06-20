using UnityEngine;

public class MetInspectedConditions : MonoBehaviour, IMet
{
    [SerializeField] Inspectable _requiredInspectable;
    public bool Met() => _requiredInspectable.WasFullyInspected;
}