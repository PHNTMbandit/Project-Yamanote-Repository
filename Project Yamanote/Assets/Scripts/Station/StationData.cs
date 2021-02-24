using System;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;

namespace ProjectYamanote.Station
{
    [Serializable]
    public class Schedule
    {
        public string origin;
        public string destination;
        public string timeArriveOrigin;
        public string timeArriveDestination;
        public string trainLine;
        public GameObject trainPrefab;
        public DateTime timeArriveOriginDT;
        public DateTime timeArriveDestinationDT;
    }

    public class StationData : MonoBehaviour
    {
        public List<Schedule> trainSchedule = new List<Schedule>();

        private void Awake()
        {
            foreach (var i in trainSchedule)
            {
                // Converts time strings to datetime
                DateTime.TryParseExact(i.timeArriveOrigin, "H:mm", CultureInfo.InvariantCulture, DateTimeStyles.None, out i.timeArriveOriginDT);
                DateTime.TryParseExact(i.timeArriveDestination, "H:mm", CultureInfo.InvariantCulture, DateTimeStyles.None, out i.timeArriveDestinationDT);
            }
        }
    }
}