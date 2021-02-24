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

        public void OnValueChanage(int val)
        {
            stationDB.stationDatabase[val].mapIcon.GetComponent<Button>().onClick.Invoke();
        }
    }
}