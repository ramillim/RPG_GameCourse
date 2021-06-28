using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MiniGameManager : MonoBehaviour
{
    public TMP_Text MiniGameTxt;
    Action<MiniGameResult> _completeInspection;
    public static MiniGameManager Instance { get; private set; }

    void Awake() => Instance = this;

    /*void Update()
    {
        if (Input.GetKeyDown(KeyCode.Y))
        {
            _completeInspection?.Invoke();
            _completeInspection = null;
        }
    }*/

    public void StartMiniGame(Action<MiniGameResult> completeInspection)
    {
        WinLoseMiniGamePanel.Instance.StartMiniGame(completeInspection);
    }
}