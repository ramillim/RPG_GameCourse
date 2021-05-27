using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

[CreateAssetMenu(menuName = "Quest")]
public class Quest : ScriptableObject
{
    public event Action Changed;
    
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
    public Step CurrentStep => Steps[_currentStepIndex];

    void OnEnable()
    {
        _currentStepIndex = 0;
        foreach (var step in Steps)
            foreach (var objective in step.Objectives)
                if (objective.GameFlag != null)
                    objective.GameFlag.Changed += HandleFlagChanged;
                
            
        
    }

    void HandleFlagChanged()
    {
        TryProgress();
        Changed?.Invoke();
    }

    public void TryProgress()
    {
        var currentStep = GetCurrentStep();
        if (currentStep.HasAllObjectivesCompleted())
        {
            _currentStepIndex++;
            Changed?.Invoke();
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
    [SerializeField] ObjectiveType _objectivetype;
    [SerializeField] GameFlag _gameFlag;
    public GameFlag GameFlag => _gameFlag;

    public enum ObjectiveType
    {
        Flag,
        Item,
        Kill,
    }

    public bool IsCompleted
    {
        get
        {
            switch (_objectivetype)
            {
                case ObjectiveType.Flag: return _gameFlag.Value;
                default: return false;
            }
        }
    }

    

    public override string ToString()
    {
        switch (_objectivetype)
        {
            case ObjectiveType.Flag: return _gameFlag.name;
            default: return _objectivetype.ToString();
        }
    }
}