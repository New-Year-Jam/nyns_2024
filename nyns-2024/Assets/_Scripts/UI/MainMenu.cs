using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField]
    private GameObject _settingsUI;
    
    [SerializeField]
    private GameObject _tutorialUI;
    
    [SerializeField]
    private GameObject _creditsUI;

    [SerializeField]
    private AudioManager _audioManager;

    public void StartGame()
    {
        _audioManager.Stop("First Impression");
        _audioManager.Play("First Impression Stripped");
        SceneManager.LoadScene("Level");
    }

    public void ShowSettings()
    {
        bool isDisplayed = _settingsUI.activeSelf;
        _settingsUI.SetActive(!isDisplayed);
        
        if (_settingsUI.activeSelf)
        {
            _audioManager.Play("UI Open");
        }
        else
        {
            _audioManager.Play("UI Close");
        }
    }

    public void ShowTutorial()
    {
        bool isDisplayed = _tutorialUI.activeSelf;
        _tutorialUI.SetActive(!isDisplayed);

        if (_tutorialUI.activeSelf)
        {
            _audioManager.Play("UI Open");
        }
        else
        {
            _audioManager.Play("UI Close");
        }
    }

    public void ShowCredits()
    {
        bool isDisplayed = _creditsUI.activeSelf;
        _creditsUI.SetActive(!isDisplayed);

        if (_creditsUI.activeSelf)
        {
            _audioManager.Play("UI Open");
        }
        else
        {
            _audioManager.Play("UI Close");
        }
    }

    public void QuitGame()
    {
        Debug.Log("Quitting game...");
        Application.Quit();
    }
}
