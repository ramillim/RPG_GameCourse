using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class QuestPanel : ToggleablePanel
{
    [SerializeField] private Quest _selectedQuest;
    Step _selectedStep => _selectedQuest.CurrentStep;
    [SerializeField] private TMP_Text _nameText;
    [SerializeField] private TMP_Text _descriptionText;
    [SerializeField] private TMP_Text _currentObjectives;
    [SerializeField] private Image _iconImage;

    [ContextMenu("Bind")]
    public void Bind()
    {
        _iconImage.sprite = _selectedQuest.sprite;
        _nameText.SetText(_selectedQuest.DisplayName);
        _descriptionText.SetText(_selectedQuest.Description);
        StringBuilder builder = new StringBuilder();
        DisplayStepsandObjectives();
        Show();
    }
    void DisplayStepsandObjectives()
    {
        StringBuilder builder = new StringBuilder();
        if (_selectedStep != null)
        {
            builder.AppendLine(_selectedStep.Instructions);
            foreach (var objective in _selectedStep.Objectives)
            {
                string rgb = objective.IsCompleted ? "green" : "gray";
                builder.AppendLine($"<color=#{rgb}>{objective}</color>");
            }
        }

        _currentObjectives.SetText(builder.ToString());
    }

    public void SelectQuest(Quest quest)
    {
        _selectedQuest = quest;
        Bind();
        Show();
        _selectedQuest.Changed += DisplayStepsandObjectives;
        //_selectedQuest.Changed -= DisplayStepsandObjectives;
    }
}