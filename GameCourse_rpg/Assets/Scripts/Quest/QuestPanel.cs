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

    private void DisplayStepsandObjectives()
    {
        StringBuilder builder = new StringBuilder();
        if (_selectedStep != null)
        {
            builder.AppendLine(_selectedStep.Instructions);
            foreach (var objective in _selectedStep.Objectives)
            {
                builder.AppendLine(objective.ToString());
            }
        }

        _currentObjectives.SetText(builder.ToString());
    }

    public void SelectQuest(Quest quest)
    {
        _selectedQuest.Progressed -= DisplayStepsandObjectives;
        _selectedQuest = quest;
        Bind();
        Show();
        _selectedQuest.Progressed += DisplayStepsandObjectives;
    }
}