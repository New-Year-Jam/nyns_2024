using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Password", menuName = "nyns-2024/Password", order = 0)]
public class Password : ScriptableObject {
    [Header("Password Information")]
    [SerializeField] int password;
    [SerializeField] Signal positiveSignal;
    [SerializeField] bool changePositiveSignalTo;
    [SerializeField] Signal negativeSignal;
    [SerializeField] bool changeNegativeSignalTo;

    public bool checkCode(int test){return test == password ? true : false;}
    public void activatePositiveSignal(){positiveSignal.changeState(changePositiveSignalTo);}
    public void activateNegativeSignal(){negativeSignal.changeState(changeNegativeSignalTo);}
}