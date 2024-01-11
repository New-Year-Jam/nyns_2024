using UnityEngine;

public class Character : Interactable
{
    [Header("Character Dialogue")]
    [SerializeField]
    [Tooltip("Triggered once, won't repeat.")]
    private Dialogue _storyDialogue;

    [SerializeField]
    [Tooltip("Remains consistent after multiple interactions.")]
    private Dialogue _repeatDialogue;

    [SerializeField]
    private DialogueSystem _dialogueSystem;

    private bool _interactable = true;
    private bool _storyComplete = false;

    private void Start()
    {
        if (_storyDialogue.getDialogueLength() == 0)
        {
            _storyComplete = true;
        }
    }

    public override void Action()
    {
        if (_interactable)
        {
            _interactable = false;
            _dialogueSystem.gameObject.SetActive(true);

            if (!_storyComplete)
            {
                _dialogueSystem.SetDialogue(this, _storyDialogue.getLines());
                _storyComplete = true;
            }
            else
            {
                if (_repeatDialogue != null)
                {
                    _dialogueSystem.SetDialogue(this, _repeatDialogue.getLines());
                }
            }
        }
    }

    public void EnableInteractivity()
    {
        _interactable = true;
    }
}
