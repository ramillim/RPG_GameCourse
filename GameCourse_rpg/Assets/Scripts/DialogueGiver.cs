using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueGiver : MonoBehaviour
{
    public enum GiverType
    {
        Npc,
        Terminal
    }

    public GiverType giver;
    [SerializeField] private TextAsset _dialogue;
    private void OnTriggerEnter(Collider other)
    {
        var player = other.GetComponent<ThirdPersonMover>();
        if (player != null)
        {
            FindObjectOfType<DialogueController>().StartDialogue(_dialogue);
            if(giver == GiverType.Npc)
                transform.LookAt(player.transform);
        }
    }
}
