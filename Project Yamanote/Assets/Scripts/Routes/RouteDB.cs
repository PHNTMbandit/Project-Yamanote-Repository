using System.Collections.Generic;
using System;
using System.Globalization;
using UnityEngine;

namespace ProjectYamanote.Routes
{
    [System.Serializable]
    public class TransferVariables
    {
        public int transferStation;
        public string transferTimeArrive;
        public string transferTimeDepart;
        public string transferTrainLine;
    }

    [System.Serializable]
    public class RouteVariables
    {
        public int originStation;
        public int destinationStation;
        public int journeyCost;
        public string timeDepart;
        public string timeArrive;
        public string trainLine;
        public DateTime timeArriveDT;
        public DateTime timeDepartDT;
        public TimeSpan takeTime;
        public CultureInfo enAU = new CultureInfo("en-AU");
        public TransferVariables[] numberOfTransfers;
    }

    public class RouteDB : MonoBehaviour
    {
        public List<RouteVariables> routesList = new List<RouteVariables>();
    }
}