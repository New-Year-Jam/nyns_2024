using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

// Initiates the uiInputter and set its password-to-check variable
public class PasswordInput : Interactable
{
    [Header("Password Information")]
    [SerializeField] Password password;
    [SerializeField] InputUI uiInputter;
    
    [SerializeField] FloatingString currentPasswordAttempt;
    bool activelyInputting = false;


    public override void Action()
    {
        //show the input UI Screen.
        Debug.Log("Trying to open screen");
        activelyInputting = true;
        uiInputter.setPasswordToCheck(password);
        uiInputter.Show();
    }

    private void OnTriggerExit(Collider other)
    {
        if (activelyInputting)
        {
            // Player Leaves the input area
            Debug.Log("Left area");
            activelyInputting = false;
            uiInputter.clearAttempt();
            uiInputter.Hide();
        }
    }
}
