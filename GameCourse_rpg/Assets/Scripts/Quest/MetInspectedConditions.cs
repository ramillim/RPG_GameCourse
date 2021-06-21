using System;
using UnityEngine;

public class MetInspectedConditions : MonoBehaviour, IMet
{
    [SerializeField] Inspectable _requiredInspectable;
    public bool Met() => _requiredInspectable.WasFullyInspected;

    void OnDrawGizmos()
    {

        if (_requiredInspectable != null)
        {
            Gizmos.color = Color.green;
            //Gizmos.color = Met() ? Color.green : Color.red;
            Gizmos.DrawLine(transform.position, _requiredInspectable.transform.position);
        }
            
    }
}