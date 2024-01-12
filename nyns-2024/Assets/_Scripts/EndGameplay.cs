using UnityEngine;

public class EndGameplay : MonoBehaviour
{
    [SerializeField] Signal _endGameplay;
    [SerializeField] DialogueSystem _dialogueSystem;
    [SerializeField] Dialogue _dialogue;

    private void Update()
    {
        if (_endGameplay.getState())
        {
            Debug.Log("This is the end...");
            _dialogueSystem.gameObject.SetActive(true);
            _dialogueSystem.SetDialogue(_dialogue.getLines());
            this.enabled = false;
        }
    }
}