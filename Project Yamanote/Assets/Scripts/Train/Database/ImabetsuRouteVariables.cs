using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;

public class ImabetsuRouteVariables : MonoBehaviour
{
    [SerializeField] private TrainData trainData;

    [SerializeField] private string timeArriveOrigin;
    [SerializeField] private string timeArriveDestination;
    [SerializeField] private DateTime timeArriveOriginDT;
    [SerializeField] private DateTime timeArriveDestinationDT;

    private void Awake()
    {
        // Converts time strings to datetime
        DateTime.TryParseExact(timeArriveOrigin, "H:mm", CultureInfo.InvariantCulture, DateTimeStyles.None, out timeArriveOriginDT);
        DateTime.TryParseExact(timeArriveDestination, "H:mm", CultureInfo.InvariantCulture, DateTimeStyles.None, out timeArriveDestinationDT);
    }

    private void Start()
    {
        trainData.SetVariables("Imabetsu Station", "Shin-Aomori Station", timeArriveOriginDT, timeArriveDestinationDT);
    }
}
