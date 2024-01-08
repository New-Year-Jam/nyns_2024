using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.ShaderKeywordFilter;
using UnityEngine;

public class DoorSystem : MonoBehaviour
{
    [SerializeField] Signal signalToListen;
    [SerializeField] bool locked;
    [SerializeField] Transform doorOpenPoint;
    [SerializeField] Transform doorClosePoint;
    bool previousSignalState;


    private void Start() {
        previousSignalState = signalToListen.getState();
    }

    private void Update() {
        bool newState = signalToListen.getState();
        if (newState != previousSignalState)
        {
            Debug.Log("Door open!");
            ChangeDoorState(newState);
            previousSignalState = newState;
        }
    }

    void ChangeDoorState(bool open)
    {
        if (!locked)
        {
            if (open)
            {
                LeanTween.move(gameObject,doorOpenPoint,1.5f).setEaseInCubic();
            } 
            else
            {
                LeanTween.move(gameObject,doorClosePoint,1.5f).setEaseInCubic();
            }         
        } 
        else
        {
            Debug.Log("Door is locked");    
        }

    }


}
