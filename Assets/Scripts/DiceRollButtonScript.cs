using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceRollButtonScript : MonoBehaviour{

    public static int diceResultTotal = -6;
    public Dice1Script dice1;
    public Dice1Script dice2;
    public int dice1Result;
    public int dice2Result;

    public void rollDice(){
        dice2.rollDiceMono();
        dice1.rollDiceMono();
    }
}
