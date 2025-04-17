/*******************************************************************
* COPYRIGHT       : 2025
* PROJECT         : Dynamic Inventory 
* FILE NAME       : IParseable.cs
* DESCRIPTION     : Interface for parsable data.
*                    
* REVISION HISTORY:
* Date             Author                    Comments
* ---------------------------------------------------------------------------
* 2005/04/05      Akram Taghavi-Burris      Created Interface
* 
*
/******************************************************************/

namespace InventorySystem.Scripts.Interfaces
{
    public interface IParsable
    {
        void Parse(string[] fields);
    }
}
