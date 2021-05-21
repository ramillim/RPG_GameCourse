using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    [SerializeField] private QuestPanel _questPanel;
    private List<Quest> _activeQuests = new List<Quest>();
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
}