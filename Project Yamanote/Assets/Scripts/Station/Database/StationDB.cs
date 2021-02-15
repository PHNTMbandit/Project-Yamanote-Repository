using UnityEngine;

namespace ProjectYamanote.Station.Database
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