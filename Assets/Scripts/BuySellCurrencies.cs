using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BuySellCurrencies : MonoBehaviour
{
    // Start is called before the first frame update

    public int currencyType;
    public TMP_InputField field;
    public Player currentPlayer;
    public float dollarToLira;
    public float dollarToEuro;
    public TurnHandler gameManager;
    
    public void SellCurrency() // INPUT FIELDA ALMAK İSTEDİĞİM EURO/TL Yİ YAZMAM LAZIM BUY İÇİN
    {
        currentPlayer = gameManager.currentPlayer;
        dollarToEuro = gameManager.euroRate;
        dollarToLira = gameManager.liraRate;
        float amount = float.Parse(field.text);
        if (currencyType == 0)
        {
            if (amount <= currentPlayer._liraAmount)
            {
                currentPlayer._dollarAmount += amount * (1/dollarToLira);
                currentPlayer._liraAmount -= amount;
            }
        }
        else if (currencyType == 1)
        {
            if (amount <= currentPlayer._euroAmount)
            {
                currentPlayer._dollarAmount += amount * (1/dollarToEuro);
                currentPlayer._euroAmount -= amount;
            }
        }
        
        gameManager.UpdateTexts();
    }

    public void BuyCurrency()
    {
        currentPlayer = gameManager.currentPlayer;
        dollarToEuro = gameManager.euroRate;
        dollarToLira = gameManager.liraRate;
        float amount = float.Parse(field.text);
        
        if (currencyType == 0)
        {
            if (amount <= currentPlayer._dollarAmount * dollarToLira)
            {
                currentPlayer._liraAmount += amount;
                currentPlayer._dollarAmount -= amount  * (1/dollarToLira);
            }
        }
        else if (currencyType == 1)
        {
            if (amount <= currentPlayer._dollarAmount * dollarToEuro)
            {
                currentPlayer._euroAmount += amount;
                currentPlayer._dollarAmount -= amount  * (1/dollarToEuro);
            }
        }
        gameManager.UpdateTexts();
    }
    

}
