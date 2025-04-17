/*******************************************************************
* COPYRIGHT       : 2025
* PROJECT         : Dynamic Inventory 
* FILE NAME       : IInteractable.cs
* DESCRIPTION     : Interface for interactable items
*                    
* REVISION HISTORY:
* Date             Author                    Comments
* ---------------------------------------------------------------------------
* 2005/04/08      Akram Taghavi-Burris      Created Interface
* 
*
/******************************************************************/

using UnityEngine;

namespace InventorySystem.Scripts.Interfaces
{
    public interface IInteractable
    {
         public void Interact(GameObject interactor);
         
    }//end IInteratable
    
}//end Namespace
