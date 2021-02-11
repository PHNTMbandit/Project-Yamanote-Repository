using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;
using PixelCrushers.DialogueSystem;

[System.Serializable]
public class Schedule
{
    public string origin;
    public string destination;
    public string timeArriveOrigin;
    public string timeArriveDestination;
    public string trainLine;
    public GameObject trainPrefab;
    public DateTime timeArriveOriginDT;
    public DateTime timeArriveDestinationDT;
}

public class StationController : MonoBehaviour
{
    public List<Schedule> trainSchedule = new List<Schedule>();
    [NonSerialized]
    public Schedule scheduleDB;
    public TrainData trainData;

    [SerializeField]
    private Transform _arrivalPosition;
    [SerializeField]
    private Transform _instantiatePosition;
    [SerializeField]
    private Transform _despawnPosition;
    [SerializeField]
    private GameObject _startingTrain;

    private void Awake()
    {
        foreach (var i in trainSchedule)
        {
            // Converts time strings to datetime
            DateTime.TryParseExact(i.timeArriveOrigin, "H:mm", CultureInfo.InvariantCulture, DateTimeStyles.None, out i.timeArriveOriginDT);
            DateTime.TryParseExact(i.timeArriveDestination, "H:mm", CultureInfo.InvariantCulture, DateTimeStyles.None, out i.timeArriveDestinationDT);
        }
    }

    public void Update()
    {
        InvokeRepeating("TrainArriving", 1, 1);
    }

    // Train enters the station
    public void TrainArriving()
    {
        foreach (var i in trainSchedule)
        {
            if (i.timeArriveOriginDT.TimeOfDay == GameClock.dateTime.TimeOfDay)
            {
                print("train arriving");
                // Spawn train and move to station
                GameObject trainInstance = Instantiate(i.trainPrefab, _instantiatePosition.position, _instantiatePosition.rotation);
                iTween.MoveTo(trainInstance, iTween.Hash("position", _arrivalPosition.position, "time", 10, "delay", 10, "easetype", iTween.EaseType.easeOutCubic, "oncomplete", "TrainArrival", "oncompletetarget", gameObject, "oncompleteparams", trainInstance));

                // Pass information through to respective train scene
                trainData.SetVariables(i.origin, i.destination, i.timeArriveOriginDT, i.timeArriveDestinationDT);
            }
        }
    }

    // Train stops at platform
    public void TrainArrival(GameObject train)
    {
        // Open door
        train.GetComponentInChildren<Animator>().SetBool("DoorsOpen", true);

        StartCoroutine(TrainDeparting(train));
    }

    // Train prepares to leave
    public IEnumerator TrainDeparting(GameObject train)
    {
        // Wait for 15 seconds
        yield return new WaitForSeconds(15);

        // Close doors
        train.GetComponentInChildren<Animator>().SetBool("DoorsOpen", false);

        // Leave station and despawn
        iTween.MoveTo(train, iTween.Hash("position", _despawnPosition.position, "time", 10, "delay", 5, "easetype", iTween.EaseType.easeInCubic, "oncomplete", "TrainDeparted", "oncompletetarget", gameObject, "oncompleteparams", train));
    }

    // Train has left the station
    public void TrainDeparted(GameObject train)
    {
        Destroy(train);
    }

    #region Start of game events
    // Special function of starting train
    public void TrainDepartureFirst()
    {
        _startingTrain.MoveTo(new Vector3(-76.56f, -0.03298116f, 0),10, 0, EaseType.easeInCubic, iTween.Hash("oncomplete", "DestroyTrain", "oncompletetarget", _startingTrain));
        Destroy(_startingTrain, 10f);
    }
    #endregion
}
