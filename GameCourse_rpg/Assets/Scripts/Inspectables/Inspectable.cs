using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public class Inspectable : MonoBehaviour
{
    static HashSet<Inspectable> _inspectablesInRange = new HashSet<Inspectable>();

    public static event Action<bool> InspectablesInRangeChanged;
    public static event Action<Inspectable, string, float> OnAnyInspectionComplete;
    public static IReadOnlyCollection<Inspectable> InspectablesInRange => _inspectablesInRange;
    public float InspectionProgress => _data?.TimeInspected ?? 0f / _timeToInspect;
    public bool WasFullyInspected => InspectionProgress >= 1f;

    [SerializeField] float _timeToInspect = 3f;
    [SerializeField] float textLife = 5f;
    [SerializeField, TextArea] string _completedInspectionText;
    [SerializeField] UnityEvent OnInspectionCompleted;

    InspectableData _data;
    IMet[] _allConditions;

    void Awake()
    {
        _allConditions = GetComponents<IMet>();
    }

    public void Bind(InspectableData inspectableData)
    {
        _data = inspectableData;
        if (WasFullyInspected)
        {
            CompleteInspection();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !WasFullyInspected && MeetsCondition())
        {
            _inspectablesInRange.Add(this);
            InspectablesInRangeChanged?.Invoke(true);
        }
    }

    public bool MeetsCondition()
    {
        foreach (var condition in _allConditions)
        {
            if (condition.Met() == false)
                return false;
        }

        return true;
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (_inspectablesInRange.Remove(this))
                InspectablesInRangeChanged.Invoke(_inspectablesInRange.Any());
        }
    }

    public void Inspect()
    {
        if (WasFullyInspected)
            return;
        _data.TimeInspected += Time.deltaTime;
       //Debug.Log($"{_data.TimeInspected}{WasFullyInspected}{_data.TimeInspected <= _timeToInspect}", gameObject);
        if (WasFullyInspected)
        {
            CompleteInspection();
        }
    }

    void CompleteInspection()
    {
        Debug.Log("Completed Inspection" , gameObject);
        //gameObject.SetActive(false);
        _inspectablesInRange.Remove(this);
        InspectablesInRangeChanged.Invoke(_inspectablesInRange.Any());
        OnInspectionCompleted.Invoke();
        OnAnyInspectionComplete?.Invoke(this, _completedInspectionText, textLife);
    }
}