using UnityEngine;

[CreateAssetMenu(fileName = "Document", menuName = "nyns-2024/Document", order = 0)]
public class Document : ScriptableObject {
    [Header("Document Info")]
    [SerializeField] string docHeader;
    
    [TextArea(15,10)]
    [SerializeField] string docBody;
}