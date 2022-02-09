using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DG.Tweening;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class TurnHandler : MonoBehaviour
{
    public int playerTurn = 0;
    public Player[] players;
    public BoardNavigation board;
    public Dice1Script diceOne;
    public Dice1Script diceTwo;
    public int overallDiceResult;
    
    
    public Player currentPlayer;
    
    public Vector3 nextZone;

    public float euroRate = 0.5f;
    public float liraRate = 10f;


    public bool rollSession;
    public bool moveSession;
    public bool decisionSession;
    public bool buySession;
    public bool endingSession;

    public GameObject rollButton;
    public GameObject buyPropertyButton;
    public GameObject passButton;
    public GameObject currentZone;

    public Image propertyImage;
    public TextMeshProUGUI fundText;

    public Camera mainCam;
    private Vector3 camStartPos;
    private Vector3 camStartRot;
    private Vector3 diceOneStartPos;
    private Vector3 diceTwoStartPos;

    public TextMeshProUGUI playerName;
    public Transform cardSet;
    public Transform cardImagesParent;

    public GameObject exchangePopup;

    public TextMeshProUGUI dollarAmount;
    public TextMeshProUGUI liraAmount;
    public TextMeshProUGUI euroAmount;
    public TextMeshProUGUI dollarToEuro;
    public TextMeshProUGUI dollarToLira;

    public TextMeshProUGUI turnDollarAmount;
    public TextMeshProUGUI turnLiraAmount;
    public TextMeshProUGUI turnEuroAmount;
    public TextMeshProUGUI turnPlayerName;
    
    public TextMeshProUGUI monopolyName;
    public TextMeshProUGUI playerOneName;
    public TextMeshProUGUI playerTwoName;
    public TextMeshProUGUI playerThreeName;
    
    private PropertyImageReset imageResetter;

    public GameObject dataHolder;
    private DataHolderScript _dataHolderScript;
    
    private void Start()
    {
        camStartPos = mainCam.transform.position;
        camStartRot = mainCam.transform.rotation.eulerAngles;
        dataHolder = GameObject.Find("dataHolder");
        _dataHolderScript = dataHolder.GetComponent<DataHolderScript>();
        
        
        
        imageResetter = GetComponent<PropertyImageReset>();
        currentPlayer = players[0];
        UpdateTexts();

    }

    private void Update()
    {
        if (rollSession)
            CheckDice();
        if (moveSession)
            MovePlayer();
    }

    public void CheckDice()
    {
        
        
        //Debug.Log("CheckDice init");
        if (diceOne.isStopped && diceTwo.isStopped)
        {
            overallDiceResult = diceOne.diceResult + diceTwo.diceResult;
            players[playerTurn].targetZone = players[playerTurn]._position + overallDiceResult;
            nextZone = board.boardElements[players[playerTurn]._position + 1].transform.position  + new Vector3(0,1.5f,0);

            rollSession = false;
            moveSession = true;
            decisionSession = false;
            buySession = false;
            endingSession = false;


            diceOne.isReset = true;
            diceTwo.isReset = true;
            diceOne.isStopped = false;
            diceTwo.isStopped = false;

            rollButton.SetActive(false);
        }
    }

    public void TimeEnded()
    {
        Debug.Log("Time has ended random action selecting!!!");
        PassRound();
    }

    void MovePlayer()
    {
        //Debug.Log("MovePlayer init");
        
        players[playerTurn].transform.position =
            Vector3.MoveTowards(players[playerTurn].transform.position, nextZone, Time.deltaTime * 10f);
        if ((nextZone - players[playerTurn].transform.position).magnitude < 1f)
        {
            players[playerTurn]._position++;
            if (players[playerTurn]._position == players[playerTurn].targetZone)
            {
                rollSession = false;
                moveSession = false;
                decisionSession = true;
                endingSession = false;
                TakeAction();
            }
            else
            {
                nextZone = board.boardElements[players[playerTurn]._position + 1].transform.position  + new Vector3(0,1.5f,0);
            }
        }
    }

    void TakeAction()
    {
        currentZone = board.boardElements[players[playerTurn]._position];
        Debug.Log("current zone inside");
        Zone zoneClass = currentZone.GetComponent<Zone>();
        if (zoneClass.GetType().IsSubclassOf(typeof(Property)))
        {
            Debug.Log("current zone if inside");
            mainCam.transform.DOMove(players[playerTurn].transform.position + new Vector3(0, 10, -7), 1.5f)
                .OnComplete(ShowCard);
        }
        else if(currentZone.GetComponent<ExchangeStation>() != null)
        {
            ExchangeStation exchange = currentZone.GetComponent<ExchangeStation>();
            exchange.UpdateCurrencies(euroRate);
            exchange.UpdateCurrencies(liraRate);
            exchangePopup.SetActive(true);
            passButton.SetActive(true);
            
        }
        else if(currentZone.GetType() == typeof(TaxZone))
        {
            
        }
        else
        {
            PassRound();
        }
    }


    public void UpdateTexts()
    {
        dollarToEuro.text = euroRate.ToString();
        dollarToLira.text = liraRate.ToString();

        dollarAmount.text = "$" + currentPlayer._dollarAmount;
        liraAmount.text = "₺" + currentPlayer._liraAmount;
        euroAmount.text = "€" + currentPlayer._euroAmount;
        turnDollarAmount.text = "$" + currentPlayer._dollarAmount;
        turnLiraAmount.text = "₺" + currentPlayer._liraAmount;
        turnEuroAmount.text = "€" + currentPlayer._euroAmount;

        monopolyName.text = _dataHolderScript.monopolyName;
        playerOneName.text = _dataHolderScript.playerOneName;
        playerTwoName.text = _dataHolderScript.playerTwoName;
        playerThreeName.text = _dataHolderScript.playerThreeName;
        
        turnPlayerName.text = currentPlayer._playerName;

        
    }
    
    

    void ShowCard()
    {
        mainCam.transform.DOLookAt(players[playerTurn].transform.position, 0.5f);
        Property prop = currentZone.GetComponent<Property>();
        propertyImage.sprite = prop.cardImage;
        if (prop._owner == null)
        {
            buyPropertyButton.SetActive(true);
            passButton.SetActive(true);
            propertyImage.DOFade(1, 0.5f);
        }
        else
        {
            if (prop.GetType() == typeof(ColoredProperty))
            {
                ColoredProperty colorProp = currentZone.GetComponent<ColoredProperty>();
                players[playerTurn].PayRent(colorProp, colorProp.CheckColorSet(), prop._owner);
            }
            else
            {
                players[playerTurn].PayRent(prop, false, prop._owner);
            }
            PassRound();
        }
        
    }

    public void BuyProperty()
    {
        Property prop = currentZone.GetComponent<Property>();
        bool bought = players[playerTurn].BuyProperty(prop);
        if (bought)
        {
            if (prop.GetType() == typeof(ColoredProperty))
            {
                ColoredProperty colorProp = currentZone.GetComponent<ColoredProperty>();
                players[playerTurn].IncreasePropertyCount(colorProp.propertyColor);
            }
            else if (prop.GetType() == typeof(StationProperty))
            {
                players[playerTurn].IncreasePropertyCount(PropertyColor.Black);
            }
            else if (prop.GetType() == typeof(UtilityProperty))
            {
                players[playerTurn].IncreasePropertyCount(PropertyColor.White);
            }

            PassRound();
            players[playerTurn].transform.position = nextZone + new Vector3(playerTurn % players.Length + 2f, 0, 0);
        }
        else
        {
            fundText.DOFade(1, 1).SetInverted();
            PassRound();
        }
    }
    


    public void PassRound()
    {
        mainCam.transform.DOMove(camStartPos, 1.5f).OnComplete(ResetTurn);
        mainCam.transform.DORotate(camStartRot, 1.5f);
    }

    void ResetTurn()
    {
        playerTurn = (playerTurn + 1) % players.Length;
        currentPlayer = players[playerTurn];
        UpdateTexts();
        TurnTimer turnTimer = GetComponent<TurnTimer>();
        turnTimer.ResetTimer();
        propertyImage.DOFade(0, 0.5f);
        imageResetter.ImageReset();
        
        
        foreach (Transform child in cardImagesParent)
        {
            if(child == cardImagesParent.GetChild(0))
                UpdatePlayerCard(PropertyColor.Brown);  
            else if(child == cardImagesParent.GetChild(1))
                UpdatePlayerCard(PropertyColor.LightBlue);
            else if(child == cardImagesParent.GetChild(2))
                UpdatePlayerCard(PropertyColor.Pink);
            else if(child == cardImagesParent.GetChild(3))
                UpdatePlayerCard(PropertyColor.Orange);
            else if(child == cardImagesParent.GetChild(4))
                UpdatePlayerCard(PropertyColor.Red);
            else if(child == cardImagesParent.GetChild(5))
                UpdatePlayerCard(PropertyColor.Yellow);
            else if(child == cardImagesParent.GetChild(6))
                UpdatePlayerCard(PropertyColor.Green);
            else if(child == cardImagesParent.GetChild(7))
                UpdatePlayerCard(PropertyColor.DarkBlue);
            else if(child == cardImagesParent.GetChild(8))
                UpdatePlayerCard(PropertyColor.Black);
            else if(child == cardImagesParent.GetChild(9))
                UpdatePlayerCard(PropertyColor.White);
        }
        
        
        
        rollButton.SetActive(true);
        rollSession = true;
        moveSession = false;
        endingSession = false;

        exchangePopup.SetActive(false);
        buyPropertyButton.SetActive(false);
        passButton.SetActive(false);
    }

    private void UpdatePlayerCard(PropertyColor color)
    {
        int propertyCount = 0;
        if (color == PropertyColor.Black)
        {
            cardSet = cardImagesParent.Find("Blacks");
            propertyCount = players[playerTurn].blackPropCount;
        }
        else if (color == PropertyColor.White)
        {
            cardSet = cardImagesParent.Find("Whites");
            propertyCount = players[playerTurn].whitePropCount;
        }
        else if (color == PropertyColor.Pink)
        {
            cardSet = cardImagesParent.Find("Pinks");
            propertyCount = players[playerTurn].pinkPropCount;
        }
        else if (color == PropertyColor.DarkBlue)
        {
            cardSet = cardImagesParent.Find("DarkBlues");
            propertyCount = players[playerTurn].darkBluePropCount;
        }
        else if (color == PropertyColor.LightBlue)
        {
            cardSet = cardImagesParent.Find("LightBlues");
            propertyCount = players[playerTurn].lightBluePropCount;
        }
        else if (color == PropertyColor.Green)
        {
            cardSet = cardImagesParent.Find("Greens");
            propertyCount = players[playerTurn].greenPropCount;
        }
        else if (color == PropertyColor.Yellow)
        {
            cardSet = cardImagesParent.Find("Yellows");
            propertyCount = players[playerTurn].yellowPropCount;
        }
        else if (color == PropertyColor.Red)
        {
            cardSet = cardImagesParent.Find("Reds");
            propertyCount = players[playerTurn].redPropCount;
        }
        else if (color == PropertyColor.Orange)
        {
            cardSet = cardImagesParent.Find("Oranges");
            propertyCount = players[playerTurn].orangePropCount;
        }
        else if (color == PropertyColor.Brown)
        {
            cardSet = cardImagesParent.Find("Browns");
            propertyCount = players[playerTurn].brownPropCount;
        }

        for (int i = 0; i < propertyCount; i++)
        {
            Image cardSprite = cardSet.transform.GetChild(i).GetComponent<Image>();
            cardSprite.DOFade(1, 0.1f);
        }
    }
   
}