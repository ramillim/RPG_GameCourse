using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueGiver : MonoBehaviour
{
    [SerializeField] private TextAsset _dialogue;
    private void OnTriggerEnter(Collider other)
    {
        var player = other.GetComponent<ThirdPersonMover>();
        if (player != null)
        {
            FindObjectOfType<DialogueController>().StartDialogue(_dialogue);
            transform.LookAt(player.transform);
        }
    }
}
