using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StationLookup : MonoBehaviour
{
    [Header("Gameobject References")]
    public TMPro.TMP_Dropdown stationDropdown;
    public TextMeshProUGUI stationNameText;
    public TextMeshProUGUI stationTypeText;
    public TextMeshProUGUI stationLocText;

    [Header("Scripts")]
    public Stations.StationDB stationDB;

    public void OnValueChanage(int val)
    {
        stationDB.stationDatabase[val].mapIcon.GetComponent<Button>().onClick.Invoke();
    }
}
