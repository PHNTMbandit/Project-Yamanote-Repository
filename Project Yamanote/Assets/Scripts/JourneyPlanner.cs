using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class JourneyPlanner : MonoBehaviour
{
    [Header("Declarables")]
    public TMPro.TMP_Dropdown originStationDropdown;
    public TMPro.TMP_Dropdown destinationStationDropdown;
    public TMPro.TMP_Dropdown sortDropdown;
    public Toggle shinkansenToggle;
    public Toggle localToggle;
    public Toggle rapidToggle;
    public Stations.StationDB stationDB;
    public Routes.RouteDB routeDB;
    [NonSerialized] public Routes.RouteVariables routeVar;
    public GameObject buttonTemplate;

    private GameObject _button;

    // List of buttons to instantiate
    public static List<GameObject> buttons = new List<GameObject>();

    private void Start()
    {
        // Initialize list
        buttons = new List<GameObject>();
    }

    public void GenerateList()
    {
        // Clear existing buttons
        if(buttons.Count > 0)
        {
            foreach (GameObject button in buttons)
            {
                Destroy(button.gameObject);
            }
            buttons.Clear();
        }

        // Checks station ID on both selected dropbox
        int topValue = originStationDropdown.value;
        int bottomValue = destinationStationDropdown.value;

        // Finds the route that meets dropdown conditions
        var result = routeDB.routesList.Where(i => i.originStation == topValue && i.destinationStation == bottomValue).Distinct().ToList();

        // Converts time strings to datetime
        foreach (var i in result)
        {
            DateTime.TryParseExact(i.timeArrive, "H:mm", CultureInfo.InvariantCulture, DateTimeStyles.None, out i.timeArriveDT);
            DateTime.TryParseExact(i.timeDepart, "H:mm", CultureInfo.InvariantCulture, DateTimeStyles.None, out i.timeDepartDT);
        }

        // Sort list as default
        var sortedResult = result.OrderBy(i => i.timeDepartDT.TimeOfDay <= GameClock.dateTime.TimeOfDay).ThenBy(i => i.timeDepartDT).ToList();

        //Sort through dropdown sorting options
        switch (sortDropdown.value)
        {
            // Fastest route
            case 1:
                sortedResult = sortedResult.OrderBy(i => i.takeTime.TotalMinutes).ThenBy(i => i.timeDepartDT.TimeOfDay).ToList();
                break;

            // Fewest changes
            case 2:
                sortedResult = sortedResult.OrderBy(i => i.numberOfTransfers.Length).ThenBy(i => i.timeDepartDT.TimeOfDay).ToList();
                break;

            // Cheapest fare
            case 3:
                sortedResult = sortedResult.OrderBy(i => i.journeyCost).ThenBy(i => i.timeDepartDT.TimeOfDay).ToList();
                break;

            // Default
            default:
                sortedResult = sortedResult.OrderBy(i => i.timeDepartDT.TimeOfDay <= GameClock.dateTime.TimeOfDay).ThenBy(i => i.timeDepartDT).ToList(); ;
                break;
        }

        // Return found results
        foreach (var i in sortedResult)
        {
            i.takeTime = i.timeArriveDT.Subtract(i.timeDepartDT).Duration();

            // Instantiate buttons
            _button = Instantiate(buttonTemplate) as GameObject;
            _button.SetActive(true);
            _button.transform.SetParent(buttonTemplate.transform.parent, false);
            buttons.Add(_button.gameObject);

            // Pass through button information
            _button.GetComponent<JourneyPlannerButton>().SetArriveTime(i.timeArriveDT);
            _button.GetComponent<JourneyPlannerButton>().SetDepartTime(i.timeDepartDT);
            _button.GetComponent<JourneyPlannerButton>().SetCost(i.journeyCost);
            _button.GetComponent<JourneyPlannerButton>().SetFirstImage(i.trainLine);
            _button.GetComponent<JourneyPlannerButton>().SetTakeTime(i.takeTime);
            _button.GetComponent<JourneyPlannerButton>().SetInTime(i.timeDepartDT);
            _button.GetComponent<JourneyPlannerButton>().SetTransferImage(i.numberOfTransfers);
        }
    }
}
