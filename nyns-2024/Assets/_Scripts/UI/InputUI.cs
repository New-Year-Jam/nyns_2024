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
    [SerializeField] GameObject _autoDialogue;
    [SerializeField] GameObject _keypadObject;
    [SerializeField] GameObject _interactiveBook;
    [SerializeField] GameObject _interactiveFish;

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
        int attempt = int.Parse(floatingString.getString());
        clearAttempt();
        Debug.Log("Making Attempt: " + attempt);
        if (passwordToCheck.checkCode(attempt))
        {
            // Attempt successful
            passwordToCheck.activatePositiveSignal();
            Hide();
            _keypadObject.SetActive(false);
            _lockedObject.SetActive(false);
            _autoDialogue.SetActive(true);
            _interactiveBook.SetActive(true);
            _interactiveFish.SetActive(true);
        }
        else
        {
            Debug.Log("Fail!");
            passwordToCheck.activateNegativeSignal();
            Hide();
        }
    }

    public void setPasswordToCheck(Password password){passwordToCheck = password;}
}