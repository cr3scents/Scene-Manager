/*
* COPYRIGHT       : 2025
* PROJECT         : Scene Manager Assignment
* FILE NAME       : Singleton.cs
* DESCRIPTION     : Singleton base class that any MonoBehaviour can inherit from
*                    
* REVISION HISTORY:
* Date          Author                  Comments
* ---------------------------------------------------------------------------
* 02.04.2025    Akram Taghavi-Burris    Created script.
* 02.19.2025    Julia Gaskin            Formatting.
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CSG.General {
    
public class Singleton<T> : MonoBehaviour where T : MonoBehaviour {
    // static instance holding Singleton reference
    private static T _instance;
    
    // public property accessing Singleton instance
    public static T Instance {get{return _instance;}}
    
    [SerializeField]
    // object persistence between scenes
    private bool _isPersistent = true;
    
    
    // AWAKE //
    protected virtual void Awake() {
        ChekForSingelton();  // check for singleton duplication
    }

    void ChekForSingelton() {
        // if instance of singleton is empty
        if (_instance == null) {
            _instance = this as T;  // make this object the instance
            CheckForPersistance();
        } else if (_instance != this) {
            // else, destroy this object
            Destroy(this);
        }
        
        // log the current instance for debugging purposes
        Debug.Log(_instance);
    }

    // CHECK FOR PERSISTENCE //
    void CheckForPersistance() {
        if (_isPersistent) {
            // if a parent object exists
            if (transform.parent != null) {
                // detach object from parent
                transform.SetParent(null);
                Debug.Log($"detach {gameObject.name}");
            }
            
            // keep object persistent between scenes
            DontDestroyOnLoad(_instance);
        }
    }
}

}
