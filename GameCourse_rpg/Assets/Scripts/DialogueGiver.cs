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
    [SerializeField] private GameObject _panel;
    private bool _isTalking;
    private StaticMessage _staticMessage;
    private DialogueController _dialogueController;

    private void Start()
    {
        _staticMessage = GetComponent<StaticMessage>();
        _dialogueController = FindObjectOfType<DialogueController>();
    }

    private void Update()
    {
        if (_isTalking)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                
                _dialogueController.Show();
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        var player = other.GetComponent<ThirdPersonMover>();
        if (player != null)
        {
            _dialogueController.StartDialogue(_dialogue);
            _isTalking = true;
            if (giver == GiverType.Npc)
                    transform.LookAt(player.transform);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        _dialogueController.Hide();
    }
}
