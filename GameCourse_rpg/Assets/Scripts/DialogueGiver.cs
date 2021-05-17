using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueGiver : MonoBehaviour
{
    public enum GiverType
    {
        Npc,
        Terminal
    }

    public GiverType giver;
    [SerializeField] private TextAsset _dialogue;
    [SerializeField] private GameObject _panel;
    private bool _isTalking;

    private void Update()
    {
        if (_isTalking)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                FindObjectOfType<DialogueController>().StartDialogue(_dialogue);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        var player = other.GetComponent<ThirdPersonMover>();
        if (player != null)
        {
            _panel.SetActive(true);
            _isTalking = true;
            if(giver == GiverType.Npc)
                transform.LookAt(player.transform);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        _panel.SetActive(false);
    }
}
