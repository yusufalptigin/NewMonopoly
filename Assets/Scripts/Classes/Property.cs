using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using Image = UnityEngine.UI.Image;

public abstract class Property : Zone
{
    public float _propertyPrice;
    public float[] _rentAmount;
    public bool _isMortgaged = false;
    public Player _owner = null; // null means bank owns it.
    public Sprite cardImage;
    public bool isBought;


    public float PropertyPrice
    {
        get { return _propertyPrice; }
        set
        {
            if (value > 0)
            {
                _propertyPrice = value;
            }
        }
    }

    public float[] RentAmount
    {
        get
        {
            return _rentAmount;
        }
        set
        {
            for (int i = 0; i < _rentAmount.Length; i++)
            {
                if (value[i] > 0)
                    _rentAmount[i] = value[i];
            }

        }
    }

    public bool IsMortgaged
    {
        get { return _isMortgaged; }
        set { _isMortgaged = value; }
    }

    public Player Owner
    {
        get { return _owner; }
        set { _owner = value; }
    }

    public abstract float GetRentAmount();

    public void Mortgage()
    {

    }

    public override void OnArrival()
    {
        base.OnArrival(); // This will change
    }
    

}
