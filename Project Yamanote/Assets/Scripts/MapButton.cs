using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MapButton : MonoBehaviour
{
    [Header("Declarables")]
    public TextMeshProUGUI stationNameText;
    public TextMeshProUGUI stationTypeText;
    public TextMeshProUGUI stationLocText;
    public Stations.StationDB stationDB;
    private Image stationImageColour;

    // other variable declarations
    public Color nonSelected;
    public Color selected;

    public void Button(int val)
    {
        for (int i = 0; i < stationDB.stationDatabase.Length; i++)
        {
            // Selected
            if (i == val)
            {
                // Change button colour
                stationDB.stationDatabase[i].mapIcon.GetComponent<Image>().color = selected;
                // Change station text name
                stationNameText.text = stationDB.stationDatabase[val].name;
                // Change station text type
                stationTypeText.text = stationDB.stationDatabase[val].type;
                // Change station location text
                stationLocText.text = stationDB.stationDatabase[val].location;
            }
            // Not selected
            else
            {
                // Change button colour
                stationDB.stationDatabase[i].mapIcon.GetComponent<Image>().color = nonSelected;
            }
        }
    }
}
