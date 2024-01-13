using UnityEngine;

public class HookCombination : MonoBehaviour
{
    [SerializeField] Signal hook1;
    [SerializeField] GameObject _fish1;
    [SerializeField] Signal hook2;
    [SerializeField] GameObject _fish2;
    [SerializeField] Signal hook3;
    [SerializeField] GameObject _fish3;
    [SerializeField] Signal hook4;
    [SerializeField] GameObject _fish4;
    [SerializeField] Signal hook5;
    [SerializeField] GameObject _fish5;
    [SerializeField] Signal hook6;
    [SerializeField] GameObject _fish6;
    [SerializeField] GameObject _openHatch;

    private void Update()
    {
        if (hook1.getState())
        {
            _fish1.SetActive(true);
        }

        if (hook2.getState())
        {
            _fish2.SetActive(true);
        }

        if (hook3.getState())
        {
            _fish3.SetActive(true);
        }

        if (hook4.getState())
        {
            _fish4.SetActive(true);
        }

        if (hook5.getState())
        {
            _fish5.SetActive(true);
        }
        
        if (hook6.getState())
        {
            _fish6.SetActive(true);
        }

        if (hook1.getState() && hook2.getState() && hook3.getState() && hook4.getState() && hook5.getState() && hook6.getState())
        {
            _openHatch.GetComponent<EndGameplay>().enabled = true;
            _openHatch.GetComponent<EndAnimation>().enabled = true;

            // Prevent this script from running throughout the rest of the game.
            this.enabled = false;
        }
    }
}