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
    [SerializeField] float doorOpenSpeed = 1.0f;
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
                LeanTween.move(gameObject,doorOpenPoint,doorOpenSpeed).setEaseOutCubic();
            } 
            else
            {
                LeanTween.move(gameObject,doorClosePoint,doorOpenSpeed).setEaseOutCubic();
            }         
        } 
        else
        {
            Debug.Log("Door is locked");    
        }

    }


}
