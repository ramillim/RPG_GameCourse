using System;
using UnityEngine;

public class FlippyBoxMiniGamePanel : MonoBehaviour
{
    Action<MiniGameResult> _completeInspection;
    public static  FlippyBoxMiniGamePanel Instance { get; private set; }

    void Awake() => Instance = this;

    void Start() => gameObject.SetActive(false);

    public void StartMiniGame(Action<MiniGameResult> completeInspection)
    {
        _completeInspection = completeInspection;
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