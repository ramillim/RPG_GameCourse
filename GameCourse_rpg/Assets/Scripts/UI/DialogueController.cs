using System.Text;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Ink.Runtime;

public class DialogueController : ToggleablePanel
{
    
    [SerializeField] private TMP_Text _storyText;
    [SerializeField] private Button[] _choiceButtons;
    Story _story;
    

    [ContextMenu("Start Dialogue")]
    public void StartDialogue(TextAsset _dialogue)
    {
        _story = new Story(_dialogue.text);
        RefreshView();
        Show();
    }
    

    private void RefreshView()
    {
        StringBuilder storyTextBuilder = new StringBuilder();
        while (_story.canContinue)
            storyTextBuilder.AppendLine(_story.Continue());
        _storyText.SetText(storyTextBuilder);
        for (int i = 0; i < _choiceButtons.Length; i++)
        {
            var button = _choiceButtons[i];
            button.gameObject.SetActive(i < _story.currentChoices.Count);
            button.onClick.RemoveAllListeners();
            if (i < _story.currentChoices.Count)
            {
                var choice = _story.currentChoices[i];
                button.GetComponentInChildren<TMP_Text>().SetText(choice.text);
                button.onClick.AddListener(() =>
                {
                    _story.ChooseChoiceIndex(choice.index);
                    RefreshView();
                });
            }
        }
        HandleTags();
    }

    void HandleTags()
    {
        foreach (var tag in _story.currentTags)
        {
            Debug.Log(tag);
            if (tag.StartsWith("E."))
            {
                string eventName = tag.Remove(0, 2);
                GameEvent.RaiseEvent(eventName);
            }
            else if (tag.StartsWith("Q."))
            {
                string questName = tag.Remove(0, 2);
                QuestManager.Instance.AddQuestByName(questName);
            }
            else if (tag.StartsWith("F."))
            {
                var values = tag.Split('.');
                //string flagName = tag.Remove(0, 2);
                FlagManager.Instance.Set(values[1], values[2]);
            }
        }
    }
}