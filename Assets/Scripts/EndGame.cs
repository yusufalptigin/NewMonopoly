using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EndGame : MonoBehaviour
{
    public TextMeshProUGUI LobbyIdText;
    public TextMeshProUGUI WinnerText;
    public TextMeshProUGUI LiquidityDollar;
    public TextMeshProUGUI LiquidityEuro;
    public TextMeshProUGUI LiquidityLira;

    public Game game;

    public static Dictionary<PropertyColor, Color32> Colors = new Dictionary<PropertyColor, Color32>()
        {
            {PropertyColor.Brown, new Color32(150, 83, 54, 255)},
            {PropertyColor.LightBlue, new Color32(170, 224, 250, 255)},
            {PropertyColor.Pink, new Color32(217, 58, 150, 255)},
            {PropertyColor.Orange, new Color32(247, 148, 29, 255)},
            {PropertyColor.Red, new Color32(237, 27, 36, 255)},
            {PropertyColor.Yellow, new Color32(254, 242, 0, 255)},
            {PropertyColor.Green, new Color32(31, 178, 90, 255)},
            {PropertyColor.DarkBlue, new Color32(0, 114, 187, 255)},

};

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (game.done)
        {
            if (game.player_monopoly._isBankrupt)
            {
                WinnerText.text = "Team Wins";

                LiquidityDollar.text = "$" + game.teamDollar.ToString();
                LiquidityEuro.text = "€" + game.teamEuro.ToString();
                LiquidityLira.text = "TL " + game.teamLira.ToString();

                int i = 0;
                int ymargin = -1;

                foreach (Image image in game.PropertyImages)
                {
                    image.enabled = false;
                }

                foreach (Property property in game.teamproperties)
                {
                    game.PropertyImages[i].enabled = true;

                    if (property is ColoredProperty)
                    {
                        ColoredProperty temp = property as ColoredProperty;
                        Colors.TryGetValue(temp.propertyColor, out Color32 tempcolor);
                        game.PropertyImages[i].color = tempcolor;
                    }
                    else if (property is StationProperty)
                    {
                        game.PropertyImages[i].color = new Color32(9, 10, 14, 255);
                    }
                    else
                    {
                        game.PropertyImages[i].color = new Color32(255, 255, 255, 255);
                    }

                    if (i % 3 == 0)
                    {
                        ymargin++;
                    }
                    game.PropertyImages[i].transform.position += new Vector3((i%3)*80, -ymargin * 50, 0);
                    Debug.Log(i);
                    i++;
                }
            }
            else
            {
                WinnerText.text = "Monopoly Wins";

                LiquidityDollar.text = "$" + game.player_monopoly.DollarAmount.ToString();
                LiquidityEuro.text = "€" + game.player_monopoly.EuroAmount.ToString();
                LiquidityLira.text = "TL " + game.player_monopoly.LiraAmount.ToString();

                int i = 0;
                int ymargin = -1;

                foreach (Image image in game.PropertyImages)
                {
                    image.enabled = false;
                }

                foreach (Property property in game.player_monopoly.Properties)
                {
                    game.PropertyImages[i].enabled = true;

                    if (property is ColoredProperty)
                    {
                        ColoredProperty temp = property as ColoredProperty;
                        Colors.TryGetValue(temp.propertyColor, out Color32 tempcolor);
                        game.PropertyImages[i].color = tempcolor;
                    }
                    else if (property is StationProperty)
                    {
                        game.PropertyImages[i].color = new Color32(9, 10, 14, 255);
                    }
                    else
                    {
                        game.PropertyImages[i].color = new Color32(255, 255, 255, 255);
                    }

                    if (i % 3 == 0)
                    {
                        ymargin++;
                    }
                    game.PropertyImages[i].transform.position += new Vector3((i % 3) * 80, -ymargin * 50, 0);
                    Debug.Log(i);
                    i++;
                }
            }

            game.done = false;
        }
    }
}
