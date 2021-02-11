using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Station : MonoBehaviour
{
    #region State Variables
    public StationStateMachine StateMachine { get; private set; }
    public StationArrivingState ArrivingState { get; private set; }
    public StationArrivedState ArrivedState { get; private set; }
    public StationDepartingState DepartingState { get; private set; }
    public StationDespawnState DespawnState { get; private set; }
    #endregion

    #region Components
    public Animator Animator { get; private set; }
    #endregion

    #region Check Variables
    public bool isArrived;
    public bool isDeparting;
    #endregion

    #region Other Variables
    [SerializeField] private StationData _stationData;
    [SerializeField] private Transform _arrivalPosition;
    [SerializeField] private Transform _instantiatePosition;
    [SerializeField] private Transform _despawnPosition;
    [SerializeField] private GameObject _train;
    #endregion

    #region Unity Callback Functions
    private void Awake()
    {
        StateMachine = new StationStateMachine();

        ArrivingState = new StationArrivingState(this, StateMachine, _stationData, "arriving");
        ArrivedState = new StationArrivedState(this, StateMachine, _stationData, "arrived");
        DepartingState = new StationDepartingState(this, StateMachine, _stationData, "departing");
        DespawnState = new StationDespawnState(this, StateMachine, _stationData, "despawn");
    }

    private void Start()
    {
        Animator = _train.GetComponentInChildren<Animator>();

        StateMachine.Initialise(DespawnState);
    }

    private void Update()
    {
        StateMachine.CurrentState.LogicUpdate();
    }

    private void FixedUpdate()
    {
        StateMachine.CurrentState.PhysicsUpdate();
    }
    #endregion

    #region Set Functions
    #endregion

    #region Check Functions
    public void TrainArrived()
    {
        isArrived = true;
    }
    public void TrainDeparted()
    {
        isDeparting = false;
    }
    #endregion

    #region Other Functions
    private void AnimationTrigger() => StateMachine.CurrentState.AnimationTrigger();

    private void AnimationFinishTrigger() => StateMachine.CurrentState.AnimationFinishTrigger();

    // Train enters the station
    public void TrainArriving()
    {
        foreach (var i in _stationData.trainSchedule)
        {
            // Spawn train and move to station
            iTween.MoveTo(_train, iTween.Hash("position", _arrivalPosition.position, "time", 10, "delay", 10, 
                "easetype", iTween.EaseType.easeOutCubic, "oncomplete", "TrainArrived", "oncompletetarget", gameObject));

            // Pass information through to respective train scene
            _train.GetComponent<TrainData>().SetVariables(i.origin, i.destination, i.timeArriveOriginDT, i.timeArriveDestinationDT);
        }
    }

    // Train has arrived
    public IEnumerator TrainArrivedCouroutine()
    {
        // Wait for 10 seconds
        yield return new WaitForSeconds(10);

        isDeparting = true;
    }

    // Train prepares to leave
    public IEnumerator TrainDepartingCouroutine()
    {
        isArrived = false;

        // Leave station and despawn
        iTween.MoveTo(_train, iTween.Hash("position", _despawnPosition.position, "time", 10, "delay", 5, 
            "easetype", iTween.EaseType.easeInCubic, "oncomplete", "TrainDeparted", "oncompletetarget", gameObject));

        yield return null;
    }

    // Train has left the station
    public void TrainReset()
    {
        _train.transform.position = _instantiatePosition.position;
    }
    #endregion
}
