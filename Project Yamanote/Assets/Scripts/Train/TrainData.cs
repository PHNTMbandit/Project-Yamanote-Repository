using System;
using UnityEngine;

namespace ProjectYamanote.Train
{
    public class TrainData : MonoBehaviour
    {
        public static string originStation;
        public static string destinationStation;
        public static string trainLine;
        public static DateTime timeArriveOriginDT;
        public static DateTime timeArriveDestinationDT;

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