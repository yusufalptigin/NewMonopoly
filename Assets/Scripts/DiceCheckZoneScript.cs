using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceCheckZoneScript : MonoBehaviour{
    Vector3 dice1Velocity;
    private bool isStopped = false;
    private Dice1Script diceScript;

  

    void OnTriggerStay(Collider col){
        if(dice1Velocity.magnitude == 0 && !isStopped)
        {
            if (col.gameObject.name == "Dice1Side1")
            {
                Debug.Log("6");
            }
            else if (col.gameObject.name == "Dice1Side2")
            {
                Debug.Log("5");
            }
            else if (col.gameObject.name == "Dice1Side3")
            {
                Debug.Log("4");
            }
            else if (col.gameObject.name == "Dice1Side4")
            {
                Debug.Log("3");
            }
            else if (col.gameObject.name == "Dice1Side5")
            {
                Debug.Log("2");
            }
            else if (col.gameObject.name == "Dice1Side6")
            {
                Debug.Log("1");
            }
            isStopped = true;
        }
        
    }

}
