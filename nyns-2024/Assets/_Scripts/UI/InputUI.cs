using TMPro;
using UnityEngine;

// Handles ONLY the visual aspects of the keypad and button functionality.
public class InputUI : MonoBehaviour {
    
    [SerializeField] Transform inPoint;
    [SerializeField] Transform outPoint;
    [SerializeField] TextMeshProUGUI inputText;
    [SerializeField] FloatingString floatingString;
    Password passwordToCheck;

    public void Show()
    {
        Debug.Log("Trying to show");
        LeanTween.moveY(gameObject,inPoint.localPosition.y,1.0f).setEaseInCubic();
    }
    public void Hide(){
        passwordToCheck = null;
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
            passwordToCheck.activateSignal();
            Debug.Log("Success!");
            Hide();
        }
        else
        {
            Debug.Log("Fail!");
            Hide();
        }
    }

    public void setPasswordToCheck(Password password){passwordToCheck = password;}



}