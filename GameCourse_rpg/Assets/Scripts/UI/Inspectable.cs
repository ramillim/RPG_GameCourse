using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public class Inspectable : MonoBehaviour
{ 
    static HashSet<Inspectable> _inspectablesInRange = new HashSet<Inspectable>();

    public static event Action<bool> InspectablesInRangeChanged;
    public static IReadOnlyCollection<Inspectable> InspectablesInRange => _inspectablesInRange;
    public float InspectionProgress => _data.TimeInspected / _timeToInspect;
    public bool WasFullyInspected => InspectionProgress >= 1f;
    
    [SerializeField] float _timeToInspect = 3f;
    [SerializeField] UnityEvent OnInspectionCompleted;
    
    InspectableData _data;

    public void Bind(InspectableData inspectableData)
    {
        _data = inspectableData;
        if (_data.TimeInspected >= _timeToInspect)
        {
            CompleteInspection();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !WasFullyInspected)
        {
            _inspectablesInRange.Add(this);
            InspectablesInRangeChanged?.Invoke(true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if(_inspectablesInRange.Remove(this))
                InspectablesInRangeChanged.Invoke(_inspectablesInRange.Any());
        }
    }

    public void Inspect()
    {
        _data.TimeInspected += Time.deltaTime;
        if (_data.TimeInspected >= _timeToInspect)
        {
            CompleteInspection();
        }
    }

    void CompleteInspection()
    {
        //gameObject.SetActive(false);
        _inspectablesInRange.Remove(this);
        InspectablesInRangeChanged.Invoke(_inspectablesInRange.Any());
        OnInspectionCompleted.Invoke();
    }

    
}