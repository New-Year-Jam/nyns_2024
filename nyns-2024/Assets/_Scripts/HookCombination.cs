using UnityEngine;

public class HookCombination : MonoBehaviour
{
    [SerializeField] Signal hook1;
    [SerializeField] Signal hook2;
    [SerializeField] Signal hook3;
    [SerializeField] Signal hook4;
    [SerializeField] Signal hook5;
    [SerializeField] Signal hook6;
    [SerializeField] GameObject displaySuccess;

    private void Update()
    {
        if (hook1.getState() && hook2.getState() && hook3.getState() && hook4.getState() && hook5.getState() && hook6.getState())
        {
            displaySuccess.SetActive(true);

            // Prevent this script from running throughout the rest of the game.
            this.enabled = false;
        }
    }
}