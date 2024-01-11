using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField]
    private Signal _cameraLock;
    
    [SerializeField]
    private Signal _movementLock;
    
    [SerializeField]
    private Signal _pauseLock;

    [SerializeField]
    private GameObject _dialogueUI;

    [SerializeField]
    private GameObject _pauseMenuUI;

    private void Update()
    {
        // Handles pausing and unpausing
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            _pauseLock.changeState(!_pauseLock.getState());
            UpdatePauseState();
        }
    }
    private void UpdatePauseState()
    {
        bool pauseState = _pauseLock.getState();

        // Prevent the user from moving if the the dialogue UI or the pause menu is active.
        if (_dialogueUI.activeSelf || pauseState) {
            _cameraLock.changeState(true);
            _movementLock.changeState(true);

        // Prevent the user from moving the camera if the pause menu is inactive
        // but the camera is still locked by something else.
        } else if (_cameraLock.getState() && !pauseState)
        {
            _cameraLock.changeState(true);
            _movementLock.changeState(false);
        }
        else
        {
            _cameraLock.changeState(false);
            _movementLock.changeState(false);
        }

        _pauseMenuUI.SetActive(pauseState);
    }

    public void ResumeGame()
    {
        _pauseLock.changeState(false);
        UpdatePauseState();
    }

    public void MainMenu()
    {
        _cameraLock.changeState(true);
        _movementLock.changeState(true);
        _pauseLock.changeState(false);
        
        SceneManager.LoadScene("Main Menu");
    }

    public void QuitGame()
    {
        Debug.Log("Quitting game...");
        Application.Quit();
    }
}