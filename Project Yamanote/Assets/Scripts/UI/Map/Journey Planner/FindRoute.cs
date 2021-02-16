using System.Collections.Generic;
using System.Linq;
using System;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;
using ProjectYamanote.Station.Database;
using ProjectYamanote.Routes;

namespace ProjectYamanote.UI.Map.JourneyPlanner
{
    public class FindRoute : MonoBehaviour
    {
        public TMPro.TMP_Dropdown originStationDropdown;
        public TMPro.TMP_Dropdown destinationStationDropdown;
        public TMPro.TMP_Dropdown sortDropdown;
        public Toggle shinkansenToggle;
        public Toggle localToggle;
        public Toggle rapidToggle;
        public StationDB stationDB;
        public RouteDB routeDB;
        public GameObject buttonTemplate;

        private GameObject _button;

        public static List<GameObject> buttons = new List<GameObject>();

        private void Start()
        {
            buttons = new List<GameObject>();
        }

        public void GenerateList()
        {
            if (buttons.Count > 0)
            {
                foreach (GameObject button in buttons)
                {
                    Destroy(button.gameObject);
                }
                buttons.Clear();
            }

            int topValue = originStationDropdown.value;
            int bottomValue = destinationStationDropdown.value;

            var result = routeDB.routesList.Where(i => i.originStation == topValue && i.destinationStation == bottomValue).Distinct().ToList();

            foreach (var i in result)
            {
                DateTime.TryParseExact(i.timeArrive, "H:mm", CultureInfo.InvariantCulture, DateTimeStyles.None, out i.timeArriveDT);
                DateTime.TryParseExact(i.timeDepart, "H:mm", CultureInfo.InvariantCulture, DateTimeStyles.None, out i.timeDepartDT);
            }

            var sortedResult = result.OrderBy(i => i.timeDepartDT.TimeOfDay <= GameClock.dateTime.TimeOfDay).ThenBy(i => i.timeDepartDT).ToList();

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

            foreach (var i in sortedResult)
            {
                i.takeTime = i.timeArriveDT.Subtract(i.timeDepartDT).Duration();

                _button = Instantiate(buttonTemplate) as GameObject;
                _button.SetActive(true);
                _button.transform.SetParent(buttonTemplate.transform.parent, false);
                buttons.Add(_button.gameObject);

                _button.GetComponent<ListButtonTemplate>().SetArriveTime(i.timeArriveDT);
                _button.GetComponent<ListButtonTemplate>().SetDepartTime(i.timeDepartDT);
                _button.GetComponent<ListButtonTemplate>().SetCost(i.journeyCost);
                _button.GetComponent<ListButtonTemplate>().SetFirstImage(i.trainLine);
                _button.GetComponent<ListButtonTemplate>().SetTakeTime(i.takeTime);
                _button.GetComponent<ListButtonTemplate>().SetInTime(i.timeDepartDT);
                _button.GetComponent<ListButtonTemplate>().SetTransferImage(i.numberOfTransfers);
            }
        }
    }
}

