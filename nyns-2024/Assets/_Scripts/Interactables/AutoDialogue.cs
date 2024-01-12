using UnityEngine;

public class AutoDialogue : Character {

    private void OnTriggerEnter(Collider other) {
        Action();
        this.gameObject.SetActive(false);
    }
}