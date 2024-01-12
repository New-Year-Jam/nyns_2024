using TMPro;
using UnityEngine;

// Handles the visual aspects of the keypad and button functionality.
public class InputUI : MonoBehaviour {
    
    [SerializeField] Transform inPoint;
    [SerializeField] Transform outPoint;
    [SerializeField] TextMeshProUGUI inputText;
    [SerializeField] FloatingString floatingString;
    [SerializeField] Signal cameraLock;
    [SerializeField] GameObject _lockedObject;
    [SerializeField] GameObject _scene2Dialogue;
    [SerializeField] GameObject _scene3Dialogue;
    [SerializeField] GameObject _interactiveBook;
    [SerializeField] GameObject _interactiveFish;
    [SerializeField] GameObject _tutorialPassword;
    [SerializeField] GameObject _storyPassword;
    [SerializeField] Signal _isShowing;
    private bool _tutorialMode = true;

    Password passwordToCheck;

    public void Show()
    {
        Debug.Log("Trying to show");
        cameraLock.changeState(true);
        LeanTween.moveY(gameObject,inPoint.localPosition.y,1.0f).setEaseInCubic();
    }
    public void Hide(){
        passwordToCheck = null;
        cameraLock.changeState(false);
        LeanTween.moveY(gameObject,outPoint.localPosition.y,1.0f).setEaseOutCubic();
    }
    public void UpdateText(){inputText.text = floatingString.getString();}

    public void addNumberToAttempt(string codeStr)
    {
        floatingString.changeString(floatingString.getString()+codeStr);
        UpdateText();
        Debug.Log(floatingString.getString());
    }

    public void clearAttempt()
    {
        floatingString.changeString("");
        UpdateText();
        Debug.Log(floatingString.getString());
    }

    public void enterAttempt()
    {
        //Convert string attempt to number
        _isShowing.changeState(true);
        int attempt = int.Parse(floatingString.getString());
        clearAttempt();
        Debug.Log("Making Attempt: " + attempt);
        if (passwordToCheck.checkCode(attempt))
        {
            // Attempt successful
            passwordToCheck.activatePositiveSignal();
            _isShowing.changeState(false);
            Hide();

            if (_tutorialMode)
            {
                _tutorialMode = false;
                _scene2Dialogue.SetActive(true);
                _tutorialPassword.SetActive(false);
                _storyPassword.SetActive(true);
            }
            else
            {
                _storyPassword.SetActive(false);
                _scene3Dialogue.SetActive(true);
                _lockedObject.SetActive(false);
                _interactiveBook.SetActive(true);
                _interactiveFish.SetActive(true);
            }
        }
        else
        {
            Debug.Log("Fail!");
            passwordToCheck.activateNegativeSignal();
            // Hide();
        }
    }

    public void setPasswordToCheck(Password password){passwordToCheck = password;}
}