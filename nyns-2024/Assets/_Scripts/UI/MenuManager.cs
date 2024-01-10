using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField]
    private GameObject _settingsUI;

    public void StartGame()
    {
        SceneManager.LoadScene("Level");
    }

    public void ShowSettings()
    {
        bool isDisplayed = _settingsUI.activeSelf;
        _settingsUI.SetActive(!isDisplayed);
    }

    public void ShowCredits()
    {
        Debug.Log("The credits menu...");
    }

    public void QuitGame()
    {
        Debug.Log("Quitting game...");
        Application.Quit();
    }
}
