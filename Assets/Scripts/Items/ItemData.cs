/*
 * 2025
 * Scene Manager
 * ItemData.cs
 * ScriptableObject for...
 */
 
using UnityEngine;
 
#if UNITY_EDITOR
using UnityEditor;
#endif

public enum ItemTypes {Resource, Tool, Food, Weapon, Special}
 
[CreateAssetMenu(fileName = "ItemData", menuName = "ItemData/New ItemData")]
public class ItemData : ScriptableObject, IParsable {

    //********** VARIABLES **********//
    private bool _isDataSaved = false;
    
    public string itemName;
    [TextArea(3, 10)] public string itemDescription;
    public ItemTypes itemType;
    public Sprite itemIcon;
    public int maxStackSize;
    
    // PARSE & ASSIGN FIELDS FROM CSV FILE //
    public void Parse(string[] fields) {
        _isDataSaved = bool.Parse(fields[0]);
        itemName = fields[1]; 
        itemDescription = fields[2];
        itemType = (ItemTypes)System.Enum.Parse(typeof(ItemTypes), fields[3]);
        itemIcon = Resources.Load<Sprite>(fields[4]);
        maxStackSize = int.Parse(fields[5]);
    }
    
    // ENSURE ASSET NAME == itemName FIELD //
    private void OnValidate() {
        if (string.IsNullOrEmpty(itemName)) {
            itemName = this.name;  // set name to "this" asset name
        } else {
        #if UNITY_EDITOR
            // get path of "this" asset
            string path = AssetDatabase.GetAssetPath(this);
              
            // record file name without the extension
            string currentName = System.IO.Path.GetFileNameWithoutExtension(path);
      
            // if file name != field name
            if (currentName != itemName) {
                // rename asset to field name & save
                AssetDatabase.RenameAsset(path, itemName);
                AssetDatabase.SaveAssets();
            }
        #endif
        } 
      }

}