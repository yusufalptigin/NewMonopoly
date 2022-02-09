using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StationProperty : Property
{

    public int SetNumber
    {
        get
        {
            return _owner.blackPropCount; // implement
        }
    }

    public override float GetRentAmount()
    {
        return RentAmount[SetNumber];
    }

    public StationProperty()
    {
        _rentAmount = new float[4];
    }

}
