using UnityEngine;

[System.Serializable]
public class InventorySlots : MonoBehaviour {
    //********** VARIABLES **********//
    public ItemData itemData;
    public int itemQuantity;

    // CREATE NEW INVENTORY SLOT //
    public InventorySlots(ItemData itemData, int quantity) {
        this.itemData = itemData;
        this.itemQuantity = quantity;
    }

    // ADD ITEMS TO EXISTING INVENTORY SLOT //
    public void AddQuantity(int quantity) {
        this.itemQuantity += quantity;
        
        // if new quantity exceeds stack limit, create overflow slot
        if (itemQuantity > itemData.maxStackSize) {
            int excessQuantity = itemQuantity - itemData.maxStackSize;
            new InventorySlots(itemData, excessQuantity);
            itemQuantity = itemData.maxStackSize;
        }
    }

    // REMOVE ITEMS FROM EXISTING INVENTORY SLOT //
    public void RemoveQuantity(int quantity) {
        this.itemQuantity -= quantity;

        // if new quantity < 0, set quantity to 0
        if (itemQuantity < 0) {
            itemQuantity = 0;
        }
    }
}
