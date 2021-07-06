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
    

    public void StartMiniGame(MiniGameSettings settings, Action<MiniGameResult> completeInspection)
    {
        //WinLoseMiniGamePanel.Instance.StartMiniGame(completeInspection);
        if(settings is FlippyBoxMinigameSettings flippyBoxMinigameSettings)
            FlippyBoxMiniGamePanel.Instance.StartMiniGame(flippyBoxMinigameSettings, completeInspection);
        else if (settings is WinLoseMiniGameSettings winLoseMiniGameSettings)
            WinLoseMiniGamePanel.Instance.StartMiniGame(completeInspection);
    }
}