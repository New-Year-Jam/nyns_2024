using UnityEngine;

public class Character : Interactable
{
    [Header("Character Dialogue")]
    [SerializeField]
    public Dialogue[] _dialogue;

    [SerializeField]
    private DialogueSystem _dialogueSystem;

    private bool _interactable = true;

    public override void Action()
    {
        if (_interactable)
        {
            _dialogueSystem.gameObject.SetActive(true);
            _dialogueSystem.SetDialogue(_dialogue);
            _interactable = false;
        }
    }
}
