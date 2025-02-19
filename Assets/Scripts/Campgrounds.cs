/*******************************************************************
* COPYRIGHT       : Year
* PROJECT         : One Wild Night
* FILE NAME       : Campgrounds.cs
* DESCRIPTION     : Level manager for the campgrounds leve
*                    
* REVISION HISTORY:
* Date            Author                  Comments
* ---------------------------------------------------------------------------
* 2025/02/12     Akram Taghavi-Burris        Created class
* 2025/02/19    Julia Gaskin                Edited for debugging.
/******************************************************************/

using System;
using System.Collections;
using System.Collections.Generic;
using CSG.Managers;
using UnityEngine;

public class Campgrounds : MonoBehaviour {
    
    private void OnTriggerEnter(Collider other) {
        Debug.Log("Enter Triggered by" + other.name);
        
        // if Player enters
        if (other.gameObject.tag.Equals("Player")) {
            Debug.Log(other.name + " has the tag Player");
            GameManager.Instance.ChangeState(GameState.GameOver);
        }

    }
    
    
}//end Campgrounds.cs