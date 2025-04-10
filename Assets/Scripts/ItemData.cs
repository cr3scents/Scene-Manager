/*
 * ItemData.cs
 * ScriptableObject for item resources.
 */

using Unity.VisualScripting;
using UnityEngine;

public enum ItemType {Resource, Tool, Food, Weapon, Special}

// CREATION MENU //
[CreateAssetMenu(fileName = "New Item", menuName = "New Item")]

public class ItemData : ScriptableObject {
    // VARIABLES //
    public string itemName;
    public ItemType itemType;
    [TextArea(3,10)] public string itemDescription;
    public Sprite icon;
    public int maxStackSize;

    private bool _isDataSaved = false;


    public void Parse(string[] fields) {
        itemName = fields[0];
        itemDescription = fields[1];
        _isDataSaved = bool.Parse(fields[2]);
        
        itemType = (ItemType)int.Parse(fields[3]);
    }
    
    // ON VALIDATE //
    // runs when there is a change in the editor
    private void OnValidate() {
        if (string.IsNullOrEmpty(itemName)) {
            // name item using GO name
            itemName = this.name;
        } else {
            // name GO using item name
            this.name = itemName;
        }
    }
}
