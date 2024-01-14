using UnityEngine;

public class HookCombination : MonoBehaviour
{
    [SerializeField] Signal hook1;
    [SerializeField] GameObject _fish1;
    [SerializeField] bool _playAudio1 = true;
    [SerializeField] Signal hook2;
    [SerializeField] GameObject _fish2;
    [SerializeField] bool _playAudio2 = true;
    [SerializeField] Signal hook3;
    [SerializeField] GameObject _fish3;
    [SerializeField] bool _playAudio3 = true;
    [SerializeField] Signal hook4;
    [SerializeField] GameObject _fish4;
    [SerializeField] bool _playAudio4 = true;
    [SerializeField] Signal hook5;
    [SerializeField] GameObject _fish5;
    [SerializeField] bool _playAudio5 = true;
    [SerializeField] Signal hook6;
    [SerializeField] GameObject _fish6;
    [SerializeField] bool _playAudio6 = true;
    [SerializeField] GameObject _openHatch;
    [SerializeField] DialogueSystem _dialogueSystem;
    [SerializeField] Dialogue _dialogue;

    [SerializeField]
    private AudioManager _audioManager;

    private void Awake()
    {
        _audioManager = FindObjectOfType<AudioManager>();
    }

    private void Update()
    {
        if (hook1.getState())
        {
            _fish1.SetActive(true);
            if(_playAudio1)
            {
                _audioManager.Play("Hook Correct 1");
                _playAudio1 = false;
            }
        }

        if (hook2.getState())
        {
            _fish2.SetActive(true);
            if(_playAudio2)
            {
                _audioManager.Play("Hook Correct 2");
                _playAudio2 = false;
            }
        }

        if (hook3.getState())
        {
            _fish3.SetActive(true);
            if(_playAudio3)
            {
                _audioManager.Play("Hook Correct 3");
                _playAudio3 = false;
            }
        }

        if (hook4.getState())
        {
            _fish4.SetActive(true);
            if(_playAudio4)
            {
                _audioManager.Play("Hook Correct 4");
                _playAudio4 = false;
            }
        }

        if (hook5.getState())
        {
            _fish5.SetActive(true);
            if(_playAudio5)
            {
                _audioManager.Play("Hook Correct 5");
                _playAudio5 = false;
            }
        }

        if (hook6.getState())
        {
            _fish6.SetActive(true);
            if(_playAudio6)
            {
                _audioManager.Play("Hook Correct 6");
                _playAudio6 = false;
            }
        }

        if (hook1.getState() && hook2.getState() && hook3.getState() && hook4.getState() && hook5.getState() && hook6.getState())
        {
            _openHatch.GetComponent<EndGameplay>().enabled = true;
            _openHatch.GetComponent<EndAnimation>().enabled = true;

            _dialogueSystem.gameObject.SetActive(true);
            _dialogueSystem.SetDialogue(_dialogue.getLines());
            // Prevent this script from running throughout the rest of the game.
            this.enabled = false;
        }
    }
}