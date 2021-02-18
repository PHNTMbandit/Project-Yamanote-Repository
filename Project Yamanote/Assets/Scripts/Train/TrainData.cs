using System;
using UnityEngine;

namespace ProjectYamanote.Train
{
    public class TrainData : MonoBehaviour
    {
        [NonSerialized] public static string originStation;
        [NonSerialized] public static string destinationStation;
        [NonSerialized] public static string trainLine;
        [NonSerialized] public static DateTime timeArriveOriginDT;
        [NonSerialized] public static DateTime timeArriveDestinationDT;

        public void SetVariables(string originStationString, string destinationStationString, DateTime timeArriveOrigin, DateTime timeArriveDestination, string trainline)
        {
            originStation = originStationString;
            destinationStation = destinationStationString;
            timeArriveOriginDT = timeArriveOrigin;
            timeArriveDestinationDT = timeArriveDestination;
            trainLine = trainline;
        }
    }
}