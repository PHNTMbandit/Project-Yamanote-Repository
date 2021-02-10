using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainData : MonoBehaviour
{
    [NonSerialized] public string originStation;
    [NonSerialized] public string destinationStation;
    [NonSerialized] public DateTime timeArrive;
    [NonSerialized] public DateTime timeDepart;

    // Receieve values based on current route
    public void SetVariables(string originStationString, string destinationStationString, DateTime timeArriveDT, DateTime timeDepartDT)
    {
        originStation = originStationString;
        destinationStation = destinationStationString;
        timeArrive = timeArriveDT;
        timeDepart = timeDepartDT;
    }
}
