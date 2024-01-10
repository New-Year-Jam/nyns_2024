using System;
using System.Collections;
using UnityEngine;
using TMPro;

public class DialogueSystem : MonoBehaviour
{
    [SerializeField]
    private Signal _cameraLock;

    [SerializeField]
    private Signal _movementLock;

    [SerializeField]
    private TextMeshProUGUI _characterNameUI;
    
    [SerializeField]
    private TextMeshProUGUI _characterTextUI;

    [SerializeField]
    private float _textSpeed;

    private Dialogue[] _characterDialogue;
    private Character _characterComponent;
    private int _index;

    public void SetDialogue(Character characterComponent, Dialogue[] characterDialogue)
    {
        _cameraLock.changeState(true);
        _movementLock.changeState(true);

        _characterComponent = characterComponent;
        _characterDialogue = characterDialogue;
        _characterTextUI.text = "";

        StartDialogue();
    }

    private void StartDialogue()
    {
        _index = 0;
        StartCoroutine(DisplayDialogue());
    }

    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            if(_characterTextUI.text == _characterDialogue[_index].text)
            {
                Continue();
            }
            else
            {
                StopAllCoroutines();
                _characterTextUI.text = _characterDialogue[_index].text;
            }
        }
    }

    private IEnumerator DisplayDialogue()
    {
        // Immediately display the character's name.
        _characterNameUI.text = _characterDialogue[_index].characterName;
        
        // "Animate" the text displaying.
        foreach(char character in _characterDialogue[_index].text.ToCharArray())
        {
            _characterTextUI.text += character;
            yield return new WaitForSeconds(_textSpeed);
        }
    }

    private void Continue()
    {
        if (_index < _characterDialogue.Length - 1)
        {
            _index++;
            _characterTextUI.text = "";
            StartCoroutine(DisplayDialogue());
        }
        else
        {
            gameObject.SetActive(false);
            _cameraLock.changeState(false);
            _movementLock.changeState(false);
            _characterComponent.EnableInteractivity();
        }
    }
}
