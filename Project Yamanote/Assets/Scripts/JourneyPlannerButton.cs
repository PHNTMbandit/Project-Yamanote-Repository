using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Linq;

public class JourneyPlannerButton : MonoBehaviour
{
    #region Variables
    [Header("Declarables")]
    public JourneyPlanner journeyPlanner;
    public Routes.RouteDB routeDB;
    [NonSerialized]
    public Routes.RouteVariables routeVariables;
    public GameObject trainStations;

    [Header("Route Information")]
    // Text
    [SerializeField]
    private TextMeshProUGUI _textCost;
    [SerializeField]
    private TextMeshProUGUI _textArriveTime;
    [SerializeField]
    private TextMeshProUGUI _textDepartTime;
    [SerializeField]
    private TextMeshProUGUI _textInTime;
    [SerializeField]
    private TextMeshProUGUI _textTakeTime;

    // Image
    [SerializeField]
    private GameObject _gameObjectRoutes;

    // Variables
    [SerializeField]
    private GameObject _trainImage;
    [SerializeField]
    private GameObject _shinkansenImage;
    [SerializeField]
    private GameObject _divider;
    [SerializeField]
    private Color redColor;
    [SerializeField]
    private Color greenColor;

    // Button
    [SerializeField]
    private GameObject _originPin;
    [SerializeField]
    private GameObject _destinationPin;
    [SerializeField]
    private GameObject _transferPin;
    [SerializeField]
    private GameObject _stationButtons;
    public static List<GameObject> pins = new List<GameObject>();
    #endregion

    private void Start()
    {
        // Initialize list
        pins = new List<GameObject>();
    }

    #region Button Setters
    // Change cost text
    public void SetCost(int cost)
    {
        _textCost.text = cost.ToString();
        _textCost.text = string.Format("¥ {0}", cost);
    }

    // Change arrive time text
    public void SetArriveTime(DateTime arriveTime)
    {
        _textArriveTime.text = arriveTime.ToString("H:mm");
    }

    // Change depart time text
    public void SetDepartTime(DateTime departTime)
    {
        _textDepartTime.text = departTime.ToString("H:mm");
    }

    // Change transfer icons based on train line
    public void SetTransferImage(Routes.TransferVariables[] numberOfTransfer)
    {
        foreach (var i in numberOfTransfer)
        {
            if (i.transferTrainLine.Contains("JP") || i.transferTrainLine.Contains("Resort"))
            {
                GameObject trainImage = Instantiate(_trainImage, _gameObjectRoutes.transform);
                trainImage.transform.SetParent(_gameObjectRoutes.transform, false);
            }
            if (i.transferTrainLine.Contains("Shinkansen"))
            {
                GameObject trainImage = Instantiate(_shinkansenImage, _gameObjectRoutes.transform);
                trainImage.transform.SetParent(_gameObjectRoutes.transform, false);
            }
        }
    }

    // Change take time text
    public void SetTakeTime(TimeSpan takeTime)
    {
        _textTakeTime.text = takeTime.TotalMinutes.ToString() + " mins";
    }

    // Change in time text
    public void SetInTime(DateTime departTime)
    {
        TimeSpan inTime = departTime.TimeOfDay - GameClock.dateTime.TimeOfDay;

        _textInTime.text = "in " + inTime.TotalMinutes.ToString() + " mins";
        
        if (inTime.Minutes <= 0)
        {
            _textInTime.text = "Missed";
            _textInTime.color = redColor;
        }
        else
        {
            _textInTime.color = greenColor;
        }
    }

    public void SetFirstImage(string trainLine)
    {
        if (trainLine.Contains("JP"))
        {
            GameObject trainImage = Instantiate(_trainImage, _gameObjectRoutes.transform);
            trainImage.transform.SetParent(_gameObjectRoutes.transform, false);
        }
        else if (trainLine.Contains("Shinkansen"))
        {
            GameObject trainImage = Instantiate(_shinkansenImage, _gameObjectRoutes.transform);
            trainImage.transform.SetParent(_gameObjectRoutes.transform, false);
        }
    }   

    public void SetMapTrainRoute(int originStation, int destinationStation, int transferStation)
    {

    }
    #endregion

    // Click button
    public void OnClick()
    {
        string originDropdown = journeyPlanner.originStationDropdown.options[journeyPlanner.originStationDropdown.value].text;
        string destinationDropdown = journeyPlanner.destinationStationDropdown.options[journeyPlanner.destinationStationDropdown.value].text;

        GameObject originStation = GameObject.Find(originDropdown);
        GameObject destinationStation = GameObject.Find(destinationDropdown);

        GameObject originPin = Instantiate(_originPin, originStation.transform);
        originPin.transform.SetParent(originStation.transform, false);
        pins.Add(originPin.gameObject);

        GameObject destinationPin = Instantiate(_destinationPin, destinationStation.transform);
        destinationPin.transform.SetParent(destinationStation.transform, false);
        pins.Add(destinationPin.gameObject);

        // Clear existing pins
        if (pins.Count > 0)
        {
            foreach (GameObject pin in pins)
            {
                Destroy(pin.gameObject);
            }
            pins.Clear();
        }
    }
}