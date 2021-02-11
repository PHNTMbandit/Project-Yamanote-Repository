using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainData : MonoBehaviour
{
    [NonSerialized] public static string originStation;
    [NonSerialized] public static string destinationStation;
    [NonSerialized] public static DateTime timeArriveOriginDT;
    [NonSerialized] public static DateTime timeArriveDestinationDT;

    // Receieve values based on current route
    public void SetVariables(string originStationString, string destinationStationString, DateTime timeArriveOrigin, DateTime timeArriveDestination)
    {
        originStation = originStationString;
        destinationStation = destinationStationString;
        timeArriveOriginDT = timeArriveOrigin;
        timeArriveDestinationDT = timeArriveDestination;
    }
}