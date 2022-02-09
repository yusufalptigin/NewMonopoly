using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int _playerId;
    public string _playerName;
    public float _dollarAmount;
    public float _euroAmount;
    public float _liraAmount;
    public bool _hasGetOutOfJailFree;
    public int _position;  // My addition
    public int _isJailed = 0;
    public int targetZone;
    public bool _isBankrupt;
    private bool _isMonopoly;
    


    public List<Property> Properties;

    public int darkBluePropCount;
    public int lightBluePropCount;
    public int yellowPropCount;
    public int redPropCount;
    public int brownPropCount;
    public int pinkPropCount;
    public int orangePropCount;
    public int greenPropCount;
    public int blackPropCount;
    public int whitePropCount;
    

    public int PlayerId
    {
        get { return _playerId; }
        set 
        {
            if(value > 0 && value < 7)
            {
                _playerId = value;
            }
        }
    }


    public string PlayerName
    {
        get { return _playerName; }
        set { _playerName = value; }
    }


    public float DollarAmount
    {
        get { return _dollarAmount; }
        set
        {
            while(value < 0)
            {
                string selection = SelectIncomeMethod();
                switch (selection)
                {
                    case "Sell Property":
                        break;
                    case "Sell Building":
                        break;
                    case "Sell GOOTJF Card":
                        break;
                    case "Exchange Money":
                        break;
                    case "Mortgage":
                        break;
                    case "Declare Bankruptcy":
                        Bankruptcy();
                        return;
                }
            }
            _dollarAmount = value;
        }
    }


    public float EuroAmount
    {
        get { return _euroAmount; }
        set
        {
            if (value >= 0)
            {
                _euroAmount = value;
            }
        }
    }


    public float LiraAmount
    {
        get { return _liraAmount; }
        set
        {
            if (value >= 0)
            {
                _liraAmount = value;
            }
        }
    }


    public bool HasGetOutOfJailFree
    {
        get { return _hasGetOutOfJailFree; }
        set { _hasGetOutOfJailFree = value; }
    }


    public int Position
    {
        get { return _position; }
        set
        {
            if (_position > 0)
            {
                _position = value;
            }
        }
    }


    public int IsJailed
    {
        get { return _isJailed; }
        set { _isJailed = value; }
    }

    public bool IsMonopoly
    {
        get { return _isMonopoly; }
        set { _isMonopoly = value; }
    }


    public bool IsBankrupt
    {
        get { return _isBankrupt = false; }
        set { _isBankrupt = value; }
    }


    public int RollDice()
    {
        int roll = 0;
        // roll += dice1
        // roll += dice2
        return roll;
    }

    public void Move()
    {

    }

    public void UseJailFree()
    {
        if (HasGetOutOfJailFree && (IsJailed != 0))
        {
            // use
            HasGetOutOfJailFree = false;
        }
        else
        {
            // can't use
        }
    }

    public Card DrawCardChance()
    {
        Card cardDrawn = null;
        return cardDrawn;
    }

    public Card DrawCardCommunityChest()
    {
        Card cardDrawn = null;
        return cardDrawn;
    }

    public void PayRent(Property property, bool isSet, Player owner)
    {
        if (!isSet)
        {
            if (_dollarAmount > property.GetRentAmount())
            {
                _dollarAmount -= property.GetRentAmount();
                owner._dollarAmount += property.GetRentAmount();
            }
        }
        else
        {
            if (_dollarAmount > property._rentAmount[1])
            {
                _dollarAmount -= property._rentAmount[1];
                owner._dollarAmount += property._rentAmount[1];
            }
        }
        
    }

    public bool BuyProperty(Property property)
    {
        if (_dollarAmount > property._propertyPrice)
        {
            Properties.Add(property);
            property._owner = this;
            property.isBought = true;
            _dollarAmount -= property._propertyPrice;
            return true;
        }
        else
        {
            return false;
        }
        
    }

    public void SellProperty( Property property,  Player player)
    {

    }

    public void BuildHouse( Property property)   // or can pass in an int which specifies a property in Properties List
    {

    }

    public void BuildHotel( Property property)   // or can pass in an int which specifies a property in Properties List
    {

    }

    public void Mortgage( Property property)   // or can pass in an int which specifies a property in Properties List
    {

    }

    public void GoToJail()
    {

    }

    public string SelectIncomeMethod()
    {
        return null;
    }

    public void Bankruptcy()    // Game over for this player
    {

    }

    public bool JoinLobby(int LobbyId)  // void on class diagrams
    {
        return true;
    }

    public bool CreateLobby()   // void on class diagrams
    {
        return true;
    }

    public Player()
    {
        
    }

    public void IncreasePropertyCount(PropertyColor propertyColor)
    {
        if (propertyColor == PropertyColor.LightBlue)
            lightBluePropCount++;
        else if (propertyColor == PropertyColor.Black)
            blackPropCount++;
        else if (propertyColor == PropertyColor.Brown)
            brownPropCount++;
        else if (propertyColor == PropertyColor.Green)
            greenPropCount++;
        else if (propertyColor == PropertyColor.Orange)
            orangePropCount++;
        else if (propertyColor == PropertyColor.Pink)
            pinkPropCount++;
        else if (propertyColor == PropertyColor.Red)
            redPropCount++;
        else if (propertyColor == PropertyColor.Yellow)
            yellowPropCount++;
        else if (propertyColor == PropertyColor.DarkBlue)
            darkBluePropCount++;
        else if (propertyColor == PropertyColor.White)
            whitePropCount++;
    }
}
