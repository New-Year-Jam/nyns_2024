using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "Item", menuName = "nyns-2024/Item", order = 0)]
public class Item : ScriptableObject {
    [SerializeField] new string name;
    [SerializeField] Image itemImage;

    [TextArea(15,10)]
    [SerializeField] string description;
    [SerializeField] bool canPickup;


    public string getName() {return name;}
    public Image getImage() {return itemImage;}
    public string getDescription() {return description;}
    public bool pickup() {
        
        
        return true;
    }

}