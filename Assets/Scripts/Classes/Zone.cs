using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zone : MonoBehaviour
{

    private int _propertyId;
    private string _name;
    private bool _hasPlayerOnIt = false;

    public string Name
    {
        get { return _name; }
        set { _name = value; }
    }

    public int PropertyId
    {
        get { return _propertyId; }
        set
        {
            if(value >= 0)
            {
                _propertyId = value;
            }
        }
    }

    public bool HasPlayerOnIt
    {
        get { return _hasPlayerOnIt; }
        set { _hasPlayerOnIt = value; }
    }

    public virtual void OnArrival() // what happens when a player comes here, property class will override this
    {

    }
}
