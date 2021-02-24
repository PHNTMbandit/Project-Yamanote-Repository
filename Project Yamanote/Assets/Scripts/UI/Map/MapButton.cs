using UnityEngine;
using UnityEngine.UI;
using TMPro;
using ProjectYamanote.Station;

namespace ProjectYamanote.UI
{
    public class MapButton : MonoBehaviour
    {
        public TMP_Dropdown stationNameDD;
        public TextMeshProUGUI stationTypeText;
        public TextMeshProUGUI stationLocText;
        public StationDB stationDB;
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
                    stationNameDD.value = stationDB.stationDatabase[val].id;
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
}