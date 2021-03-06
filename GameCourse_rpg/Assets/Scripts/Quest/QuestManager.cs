using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    [SerializeField] QuestPanel _questPanel;
    List<Quest> _activeQuests = new List<Quest>();
    [SerializeField] List<Quest> _allQuests;
    public static QuestManager Instance { get; private set; }

    private void Awake() => Instance = this;

    /*void Start() => GameFlag.AnyChanged += ProgressQuests;

    void OnDestroy() => GameFlag.AnyChanged -= ProgressQuests;*/

    public void AddQuest(Quest quest)
    {
        _activeQuests.Add(quest);
        _questPanel.SelectQuest(quest);
    }

    public void AddQuestByName(string questName)
    {
        var quest = _allQuests.FirstOrDefault(t => t.name == questName);
        if (quest != null)
            AddQuest(quest);
        else
        {
            Debug.LogError($"Missing Quest {questName} attempted to add from dialogue");
        }
    }

    /*[ContextMenu("Progress Quest")]
    public void ProgressQuests()
    {
        foreach (var quest in _activeQuests)
        {
            quest.TryProgress();
        }
    }*/

}