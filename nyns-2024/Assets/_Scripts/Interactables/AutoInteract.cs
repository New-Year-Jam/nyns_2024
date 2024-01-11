using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AutoInteract : Interactable
{
    private void OnTriggerEnter(Collider other) {
        Action();
    }
}
