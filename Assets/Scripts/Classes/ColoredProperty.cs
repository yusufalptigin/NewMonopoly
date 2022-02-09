using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColoredProperty : Property
{
    private int _houseCount = 0;

    public PropertyColor propertyColor;

    public int HouseCount
    {
        get { return _houseCount; }
        set
        {
            if (value >= 0)
                _houseCount = value;
        }
    }

    public bool CheckColorSet()
    {
        return false;
    }

    public override float GetRentAmount()
    {
        float amount = RentAmount[_houseCount];
        if (_houseCount == 0)
        {
            if (CheckColorSet())
            {
                amount *= 2;
            }
        }
        return amount;
    }

    public void BuildHouse()
    {

    }

    public void DestroyHouse()
    {

    }

    public ColoredProperty()
    {
        _rentAmount = new float[5];
    }

}

public enum PropertyColor
{
    Brown,
    LightBlue,
    Pink,
    Orange,
    Red,
    Yellow,
    Green,
    DarkBlue,
    Black,
    White
}
