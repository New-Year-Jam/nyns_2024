using UnityEngine;

[CreateAssetMenu(fileName = "Signal", menuName = "nyns-2024/Signal", order = 0)]
public class Signal : ScriptableObject {
    [SerializeField] bool defaultState;
    bool currentState;

    public bool getState() {return currentState;}
    public void changeState(bool newState) {currentState = newState;}
    private void OnEnable() {
        currentState = defaultState;
    }
}

