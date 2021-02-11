using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainData : MonoBehaviour
{
    [NonSerialized] public string originStation;
    [NonSerialized] public string destinationStation;
    [NonSerialized] public DateTime timeArriveOriginDT;
    [NonSerialized] public DateTime timeArriveDestinationDT;

    // Receieve values based on current route
    public void SetVariables(string originStationString, string destinationStationString, DateTime timeArriveOrigin, DateTime timeArriveDestination)
    {
        originStation = originStationString;
        destinationStation = destinationStationString;
        timeArriveOriginDT = timeArriveOrigin;
        timeArriveDestinationDT = timeArriveDestination;
    }
}
