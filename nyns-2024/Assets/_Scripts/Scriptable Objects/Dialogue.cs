using System;
using UnityEngine;

[Serializable]
public struct line
{
    public string characterName;
    public string text;
}

[CreateAssetMenu(fileName = "Dialogue", menuName = "nyns-2024/Dialogue", order = 0)]
public class Dialogue : ScriptableObject {
    [SerializeField] line[] lines;
    public line[] getLines() {return lines;}
    public int getDialogueLength() {return lines.Length;}
}