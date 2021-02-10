using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Stations
{
    [System.Serializable]
    public class StationVariables
    {
        public int id;
        public string name;
        public string type;
        public string location;
        public GameObject mapIcon;
    }

    public class StationDB : MonoBehaviour
    {
        public StationVariables[] stationDatabase;
    }
}

