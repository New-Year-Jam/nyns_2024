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

    [SerializeField]
    private AudioManager _audioManager;

    private void Awake()
    {
        _audioManager = FindObjectOfType<AudioManager>();
    }

    public void Show()
    {
        _isShowing.changeState(true);
        Debug.Log("Trying to show");
        cameraLock.changeState(true);
        LeanTween.moveY(gameObject,inPoint.localPosition.y,1.0f).setEaseInCubic();
    }
    public void Hide(){
        _isShowing.changeState(false);
        passwordToCheck = null;
        cameraLock.changeState(false);
        LeanTween.moveY(gameObject,outPoint.localPosition.y,1.0f).setEaseOutCubic();
    }
    public void UpdateText(){inputText.text = floatingString.getString();}

    public void addNumberToAttempt(string codeStr)
    {
        _audioManager.Play("Keypad Number");
        floatingString.changeString(floatingString.getString()+codeStr);
        UpdateText();
        Debug.Log(floatingString.getString());
    }

    public void clearAttempt()
    {
        _audioManager.Play("Keypad Clear");
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

            if (_tutorialMode)
            {
                _tutorialMode = false;
                _scene2Dialogue.SetActive(true);
                _tutorialPassword.SetActive(false);
                _storyPassword.SetActive(true);
                _audioManager.Play("Password Correct");
            }
            else
            {
                _storyPassword.SetActive(false);
                _scene3Dialogue.SetActive(true);
                _lockedObject.SetActive(false);
                _interactiveBook.SetActive(true);
                _interactiveFish.SetActive(true);
                _audioManager.Play("Password Correct");
            }
        }
        else
        {
            Debug.Log("Fail!");
            passwordToCheck.activateNegativeSignal();
            _audioManager.Play("Password Wrong");
            // Hide();
        }
    }

    public void setPasswordToCheck(Password password){passwordToCheck = password;}
}