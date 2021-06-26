using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InspectionPanel : MonoBehaviour
{
    [SerializeField] TMP_Text _hintText;
    [SerializeField] TMP_Text _completedInspectionText;
    [SerializeField] Image _progressBarFill;
    [SerializeField] GameObject _progressBar;

    void Start()
    {
        _completedInspectionText.enabled = false;
    }

    void OnEnable()
    {
        _hintText.enabled = false;
        Inspectable.InspectablesInRangeChanged += UpdateHintTextState;
        Inspectable.OnAnyInspectionComplete += HandleAnyInspectionComplete;
    }

    void HandleAnyInspectionComplete(Inspectable inspectable, string completeInspectionText, float textLife)
    {
        _completedInspectionText.SetText(completeInspectionText);
        _completedInspectionText.enabled = true;
        StartCoroutine(FadeCompletedText(textLife));
    }

    IEnumerator FadeCompletedText(float textLife)
    {
        _completedInspectionText.alpha = 1f;
        while (_completedInspectionText.alpha > 0)
        {
            yield return null;
            _completedInspectionText.alpha -= Time.deltaTime / textLife;
        }

        _completedInspectionText.enabled = false;
    }

    void OnDisable()
    {
        Inspectable.InspectablesInRangeChanged -= UpdateHintTextState;
    }

    void Update()
    {
        if(InspectionManager.Inspecting)
        {
            _progressBarFill.fillAmount = InspectionManager.InspectionProgress;
            _progressBar.SetActive(true);
        }
        else if (_progressBar.activeSelf)
        {
            _progressBar.SetActive(false);
        }
    }

    void UpdateHintTextState(bool enabledHint) => _hintText.enabled = enabledHint;
}