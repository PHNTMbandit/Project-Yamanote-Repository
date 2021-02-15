using ProjectYamanote.Train;
using System;
using System.Globalization;
using UnityEngine;

namespace ProjectYamanote.Routes
{
    public class ImabetsuRouteVariables : MonoBehaviour
    {
        [SerializeField] private TrainData _trainData;
        [SerializeField] private string _timeArriveOrigin;
        [SerializeField] private string _timeArriveDestination;
        [SerializeField] private DateTime _timeArriveOriginDT;
        [SerializeField] private DateTime _timeArriveDestinationDT;

        private void Awake()
        {
            DateTime.TryParseExact(_timeArriveOrigin, "H:mm", CultureInfo.InvariantCulture, DateTimeStyles.None, out _timeArriveOriginDT);
            DateTime.TryParseExact(_timeArriveDestination, "H:mm", CultureInfo.InvariantCulture, DateTimeStyles.None, out _timeArriveDestinationDT);
        }

        private void Start()
        {
            _trainData.SetVariables("Imabetsu Station", "Shin-Aomori Station", _timeArriveOriginDT, _timeArriveDestinationDT);
        }
    }
}