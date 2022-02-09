using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Game : MonoBehaviour
{
    public Player player1;
    public Player player2;
    public Player player3;
    public Player player_monopoly;

    public List<Property> teamproperties;
    public float teamDollar = 0;
    public float teamEuro = 0;
    public float teamLira = 0;

    public ColoredProperty prop1;
    public ColoredProperty prop2;
    public ColoredProperty prop3;
    public ColoredProperty prop4;
    public ColoredProperty prop5;
    public UtilityProperty prop6;
    public UtilityProperty prop7;
    public StationProperty prop8;


    public TextMeshProUGUI[] PropertyTexts = new TextMeshProUGUI[28];
    public Image[] PropertyImages = new Image[28];

    public bool done = false;


    // Start is called before the first frame update
    void Start()
    {

        prop1.Name = "abcd";
        prop1.propertyColor = PropertyColor.Pink;

        prop2.Name = "Levent";
        prop2.propertyColor = PropertyColor.Green;

        prop3.propertyColor = PropertyColor.Green;

        prop4.propertyColor = PropertyColor.DarkBlue;

        prop5.propertyColor = PropertyColor.DarkBlue;

        prop3.Name = "Üsküdar Vapur İskelesi";


        teamproperties.AddRange(player1.Properties);
        teamproperties.AddRange(player2.Properties);
        teamproperties.AddRange(player3.Properties);

        teamDollar = player1.DollarAmount + player2.DollarAmount + player3.DollarAmount;
        teamEuro = player1.EuroAmount + player2.EuroAmount + player3.EuroAmount;
        teamLira = player1.LiraAmount + player2.LiraAmount + player3.LiraAmount;

        player_monopoly._isBankrupt = false;
        player_monopoly.IsMonopoly = true;
        player_monopoly.DollarAmount = 420500;
        player_monopoly.EuroAmount = 22500;
        player_monopoly.LiraAmount = 1565000;
        player_monopoly.Properties.Add(prop1);
        player_monopoly.Properties.Add(prop2);
        player_monopoly.Properties.Add(prop3);
        player_monopoly.Properties.Add(prop4);
        player_monopoly.Properties.Add(prop5);
        player_monopoly.Properties.Add(prop6);
        player_monopoly.Properties.Add(prop7);
        player_monopoly.Properties.Add(prop8);

        

        done = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
