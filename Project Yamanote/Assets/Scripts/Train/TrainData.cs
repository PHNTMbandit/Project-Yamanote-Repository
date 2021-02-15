using System;
using UnityEngine;

namespace ProjectYamanote.Train
{
    public class TrainData : MonoBehaviour
    {
        [NonSerialized] public static string originStation;
        [NonSerialized] public static string destinationStation;
        [NonSerialized] public static DateTime timeArriveOriginDT;
        [NonSerialized] public static DateTime timeArriveDestinationDT;

        public void SetVariables(string originStationString, string destinationStationString, DateTime timeArriveOrigin, DateTime timeArriveDestination)
        {
            originStation = originStationString;
            destinationStation = destinationStationString;
            timeArriveOriginDT = timeArriveOrigin;
            timeArriveDestinationDT = timeArriveDestination;
        }
    }
}