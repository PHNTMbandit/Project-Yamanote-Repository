using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Cinemachine;
using F10.StreamDeckIntegration;
using F10.StreamDeckIntegration.Attributes;
using UnityEngine.SceneManagement;
using System;
using PixelCrushers.DialogueSystem;

public class TrainController : MonoBehaviour
{
    [Header("Shake")]
    public UnityEvent shake;
    public Animator animator;
    [Header("Train Arrival")]
    public GameObject trainDoors;
    public GameObject trainStation;
    public GameObject trainWall;
    [Header("Train Variables")]
    public bool trainDeparted;
    public bool trainDeparting = false;
    public bool trainTravelling = true;
    public bool trainArriving;
    public bool trainArrived;
    public bool doorsOpen;
    [Header("Declarables")]
    public StationController stationController;

    [SerializeField]
    private PlayerController _playerController;
    private string _originStation;
    private string _destinationStation;
    private DateTime _timeArrive;
    private DateTime _timeDepart;
    private GameObject[] _parallaxBackground;

    private void Awake()
    {
        // Shake train every 30 seconds
        InvokeRepeating("TrainShake", 0, 30);
    }

    // Receieve values based on current route
    public void SetVariables(string originStationPass, string destinationStationPass, DateTime timeArrivePass, DateTime timeDepartPass)
    {
        _originStation = originStationPass;
        _destinationStation = destinationStationPass;
        _timeArrive = timeArrivePass;
        _timeDepart = timeDepartPass;
    }

    // Shake train
    public void TrainShake()
    {
        // When parallax effect stops
        if (trainTravelling == true)
        {
            shake.Invoke();
            animator.SetTrigger("Bump");
        }
    }

    // Train is arriving
    public void TrainArriving()
    {
        trainTravelling = false;
        trainArriving = true;

        // Starts slow down parallax
        _parallaxBackground = GameObject.FindGameObjectsWithTag("Parallax");
        foreach (GameObject background in _parallaxBackground)
        {
            StartCoroutine(background.GetComponent<EasyParallax.SpriteMovement>().SlowDown());
        }

        // Moves arrival station
        trainStation.MoveTo(new Vector3(-2f, -0.57f, 0f), 20, 10, EaseType.easeOutCirc);

        // Begins countdown to arrive at station
        Invoke("TrainArrival", 30);
    }

    // Train has arrived
    public void TrainArrival()
    {
        trainArriving = false;
        trainArrived = true;

        animator.SetBool("DoorOpen", true);
    }

    // Train is departing
    public void TrainDepature()
    {

    }

    // Exit through specified door
    public void Exit(string door)
    {
        PixelCrushers.SaveSystem.LoadScene(_destinationStation + "_Platform" + "@" + door);
    }

    #region Start of game events
    // Train is arriving at Shin-Aomori Station
    public void TrainArrivingFirst()
    {
        trainTravelling = false;
        trainArriving = true;

        // Starts slow down parallax
        _parallaxBackground = GameObject.FindGameObjectsWithTag("Parallax");
        foreach (GameObject background in _parallaxBackground)
        {
            StartCoroutine(background.GetComponent<EasyParallax.SpriteMovement>().SlowDown());
        }

        // Moves arrival station
        trainStation.MoveTo(new Vector3(-2f, -0.57f, 0f), 20, 10, EaseType.easeOutCirc);

        // Begins countdown to arrive at station
        Invoke("TrainArrival", 30);
    }

    // Exit through to Shin-Aomori station platform
    public void ExitFirst()
    {
        PixelCrushers.SaveSystem.LoadScene("Shin-Aomori Station_Platform");
    }
    #endregion
}