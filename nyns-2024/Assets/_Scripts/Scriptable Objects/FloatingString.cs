using UnityEngine;

[CreateAssetMenu(fileName = "FloatingString", menuName = "nyns-2024/FloatingString", order = 0)]
public class FloatingString : ScriptableObject {
    
    [SerializeField] string defaultString;
    string currentString;

    public void changeString(string change){
        currentString = change;
    }

    public string getString(){return currentString;}
    
    private void OnEnable() {
        currentString = defaultString;
    }

}