using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

[CreateAssetMenu(menuName = "Quest")]
public class Quest : ScriptableObject
{
    [SerializeField] private string _displayName;
    [TextArea] [SerializeField] private string _description;

    [Tooltip("Designer Notes, not visable to player.")] [SerializeField]
    private string _notes;

    public List<Step> Steps;
    [SerializeField] private Sprite _sprite;
    int _currentStepIndex;
    public string Description => _description;
    public string DisplayName => _displayName;
    public Sprite sprite => _sprite;

    public void TryProgress()
    {
        var currentStep = GetCurrentStep();
        if (currentStep.HasAllObjectivesCompleted())
        {
            _currentStepIndex++;
        }
    }


    Step GetCurrentStep() => Steps[_currentStepIndex];
}

[Serializable]
public class Step
{
    [SerializeField] private string _instructions;
    public string Instructions => _instructions;
    public List<Objectives> Objectives;

    public bool HasAllObjectivesCompleted()
    {
        return Objectives.TrueForAll(t => t.IsCompleted);
    }
}

[Serializable]
public class Objectives
{
    [SerializeField] private ObjectiveType _objectivetype;

    public enum ObjectiveType
    {
        Flag,
        Item,
        Kill,
    }

    public bool IsCompleted { get; set; }

    public override string ToString()
    {
        return _objectivetype.ToString();
    }
}