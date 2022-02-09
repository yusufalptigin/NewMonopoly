using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UtilityProperty : Property
{
    public int SetNumber
    {
        get
        {
            return 1; // implement
        }
    }

    public override float GetRentAmount()
    {
        int diceRoll = 0;

        return diceRoll * RentAmount[SetNumber];
    }

    public UtilityProperty()
    {
        _rentAmount = new float[] { 4, 10 };
    }
}
