using System;
using UnityEngine;

[Serializable]
public class Objectives
{
    [SerializeField] ObjectiveType _objectivetype;
    [SerializeField] GameFlag _gameFlag;
    [Header("Int Game Flags")]
    //[SerializeField] IntGameFlag _intGameFlag;
    [Tooltip("Required ammount for the counted in flag.")]
    [SerializeField]int _required;
    public GameFlag GameFlag => _gameFlag;
    //public IntGameFlag IntGameFlag => _intGameFlag;

    public enum ObjectiveType
    {
        GameFlag,
        Item,
        Kill,
    }

    public bool IsCompleted
    {
        get
        {
            switch (_objectivetype)
            {
                case ObjectiveType.GameFlag:
                {
                    if (_gameFlag is BoolGameFlag boolGameFlag)
                        return boolGameFlag.Value;
                    if (_gameFlag is IntGameFlag intGameFlag)
                        return intGameFlag.Value >= _required;
                    return false;
                }
                default: return false;
            }
        }
    }

    

    public override string ToString()
    {
        switch (_objectivetype)
        {
            case ObjectiveType.GameFlag:
            {
                if (_gameFlag is BoolGameFlag boolGameFlag)
                    return _gameFlag.name;
                if (_gameFlag is IntGameFlag intGameFlag)
                    return $"{intGameFlag.name} ({intGameFlag.Value}/{_required})";
                return "Unknown/Invalid objective Type";
            }
            default: return _objectivetype.ToString();
        }
    }
}