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
    private Signal _inventoryUI;

    [SerializeField]
    private Signal _inputUI; 

    [SerializeField]
    private GameObject _pauseMenuUI;
    [SerializeField]
    private AudioManager _audioManager;

    private void Awake()
    {
        _audioManager = FindObjectOfType<AudioManager>();
    }

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
        }
        else if (_inputUI.getState() || _inventoryUI.getState())
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
        
        _audioManager.Stop("First Impression Stripped");
        _audioManager.Stop("Locked Together");
        
        _audioManager.Play("First Impression");
        SceneManager.LoadScene("Main Menu");
    }

    public void QuitGame()
    {
        Debug.Log("Quitting game...");
        Application.Quit();
    }
}