using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExchangeStation : Zone
{
    // Start is called before the first frame update
    public void UpdateCurrencies(float multiplier)
    {
        multiplier *= Random.Range(0.8f, 1.2f);
    }



}
