using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    [SerializeField] private QuestPanel _questPanel;
    private List<Quest> _activeQuests = new List<Quest>();
    [SerializeField] private List<Quest> _allQuests;
    public static QuestManager Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

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

    public void ProgressQuest()
    {
        foreach (var quest in _activeQuests)
        {
            quest.TryProgress();
        }
    }

}