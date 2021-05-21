using System.Collections.Generic;
using UnityEngine;

public class ToggleablePanel: MonoBehaviour
{
    private CanvasGroup _canavasGroup;
    static HashSet<ToggleablePanel> _visablePanels = new HashSet<ToggleablePanel>();
    public static bool isVisible => _visablePanels.Count > 0;

    private void Awake()
    {
        _canavasGroup = GetComponent<CanvasGroup>();
        Hide();
    }
    public void Show()
    {
        _visablePanels.Add(this);
        _canavasGroup.alpha = 1f;
        _canavasGroup.interactable = true;
        _canavasGroup.blocksRaycasts = true;
    }
    public void Hide()
    {
        _visablePanels.Remove(this);
        _canavasGroup.alpha = 0f;
        _canavasGroup.interactable = false;
        _canavasGroup.blocksRaycasts = false;
    }
}