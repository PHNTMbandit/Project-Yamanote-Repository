using UnityEngine;
using UnityEngine.UI;
using TMPro;
using ProjectYamanote.Station;

namespace ProjectYamanote.UI
{
    public class StationLookup : MonoBehaviour
    {
        public TMP_Dropdown stationDropdown;
        public TextMeshProUGUI stationTypeText;
        public TextMeshProUGUI stationLocText;
        public StationDB stationDB;

        public void ButtonOnValueChange(int val)
        {
            stationDB.stationDatabase[val].mapIcon.GetComponent<Button>().onClick.Invoke();
        }

        public void DropDownOnValueChange()
        {
            stationDB.stationDatabase[stationDropdown.value].mapIcon.GetComponent<Button>().onClick.Invoke();
        }
    }
}