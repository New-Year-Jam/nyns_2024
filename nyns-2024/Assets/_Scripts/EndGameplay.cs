using UnityEngine;

public class EndGameplay : MonoBehaviour
{
    [SerializeField] Signal _endGameplay;
    [SerializeField] DialogueSystem _dialogueSystem;
    [SerializeField] Dialogue _dialogue;
    [SerializeField] GameObject _cageWall;
    [SerializeField] Transform _openPoint;
    [SerializeField] float _openSpeed;
    [SerializeField] GameObject _siren;

    private void Update()
    {
        if (_endGameplay.getState())
        {
            LeanTween.move(_cageWall, _openPoint, _openSpeed).setEaseOutCubic();
            _dialogueSystem.gameObject.SetActive(true);
            _dialogueSystem.SetDialogue(_dialogue.getLines());
            this.enabled = false;
        }
    }
}