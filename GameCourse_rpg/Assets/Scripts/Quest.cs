using System;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Quest")]
public class Quests : ScriptableObject
{
    [SerializeField] private string _name;
    [TextArea]
    [SerializeField] private string _discription;

    [Tooltip("Designer Notes, not visable to player.")] [SerializeField]
    private string _notes;
    
    public List<Step> Steps;
}
[Serializable]
public class Step
{
    [SerializeField] private string _instructions;
    public List<Objectives> Objectives;
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
}
