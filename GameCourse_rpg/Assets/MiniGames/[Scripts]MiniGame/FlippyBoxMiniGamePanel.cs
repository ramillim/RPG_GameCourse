using System;
using UnityEngine;

public class FlippyBoxMiniGamePanel : MonoBehaviour
{
    [SerializeField] FlippyBoxMinigameSettings _defaultSettings;
    Action<MiniGameResult> _completeInspection;
    public FlippyBoxMinigameSettings currentSettings { get; private set; }
    public static  FlippyBoxMiniGamePanel Instance { get; private set; }

    void Awake() => Instance = this;

    void Start()
    {
        gameObject.SetActive(false);
        if(transform.parent == null)
            StartMiniGame(_defaultSettings, (result) => Debug.Log(result));
    }

    public void StartMiniGame(FlippyBoxMinigameSettings settings, Action<MiniGameResult> completeInspection)
    {
        currentSettings = settings ?? _defaultSettings;
        _completeInspection = completeInspection;
        foreach (var restartable in GetComponentsInChildren<IRestart>())
        {
            restartable.Restart();
        }
        gameObject.SetActive(true);
    }

    public void Win()
    {
        _completeInspection?.Invoke(MiniGameResult.won);
        _completeInspection = null;
        gameObject.SetActive(false);
    }

    public void Lose()
    {
        _completeInspection?.Invoke(MiniGameResult.lose);
        _completeInspection = null;
        gameObject.SetActive(false);
    }
}