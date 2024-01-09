using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Password", menuName = "nyns-2024/Password", order = 0)]
public class Password : ScriptableObject {
    [Header("Password Information")]
    [SerializeField] int password;
    [SerializeField] Signal signalToActivate;
    [SerializeField] bool changeSignalTo;

    public bool checkCode(int test){return test == password ? true : false;}
    public void activateSignal(){signalToActivate.changeState(changeSignalTo);}
}