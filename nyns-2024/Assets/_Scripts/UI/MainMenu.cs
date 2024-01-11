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

    public void StartGame()
    {
        SceneManager.LoadScene("Level");
    }

    public void ShowSettings()
    {
        bool isDisplayed = _settingsUI.activeSelf;
        _settingsUI.SetActive(!isDisplayed);
    }

    public void ShowTutorial()
    {
        bool isDisplayed = _tutorialUI.activeSelf;
        _tutorialUI.SetActive(!isDisplayed);
    }

    public void ShowCredits()
    {
        bool isDisplayed = _creditsUI.activeSelf;
        _creditsUI.SetActive(!isDisplayed);
    }

    public void QuitGame()
    {
        Debug.Log("Quitting game...");
        Application.Quit();
    }
}
