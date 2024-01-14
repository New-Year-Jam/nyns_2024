using UnityEngine;

public class GameplayAudio : MonoBehaviour
{
    [SerializeField]
    private AudioManager _audioManager;

    private void Awake()
    {
        _audioManager = FindObjectOfType<AudioManager>();
    }

    private void OnTriggerEnter()
    {
        _audioManager.Stop("First Impression Stripped");
        _audioManager.Play("Locked Together");
    }
}