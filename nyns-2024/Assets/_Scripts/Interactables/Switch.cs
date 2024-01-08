using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : Interactable
{
    [Header("Switch Info")]
    [SerializeField] Signal signal;
    [SerializeField] bool changeToState;

    public override void Action()
    {
        Debug.Log("Button Pushed");
        signal.changeState(changeToState);
    }
}
