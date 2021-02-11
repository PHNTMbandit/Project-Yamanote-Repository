using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Train : MonoBehaviour
{
    #region State Variables
    public TrainStateMachine StateMachine { get; private set; }
    public TrainArrivedState ArrivedState { get; private set; }
    public TrainArrivingState ArrivingState { get; private set; }
    public TrainDepartingState DepartingState { get; private set; }
    public TrainTravellingState TravellingState { get; private set; }
    #endregion

    #region Components
    public Animator Animator { get; private set; }
    #endregion

    #region Check Variables
    public bool isArrived;
    #endregion

    #region Other Variables
    [SerializeField] private GameObject[] _parallaxBackground;
    [SerializeField] private GameObject _trainStation;
    [SerializeField] private TrainData _trainData;
    #endregion

    #region Unity Callback Functions
    private void Awake()
    {
        StateMachine = new TrainStateMachine();

        ArrivedState = new TrainArrivedState(this, StateMachine, _trainData, "arrived");
        ArrivingState = new TrainArrivingState(this, StateMachine, _trainData, "arriving");
        DepartingState = new TrainDepartingState(this, StateMachine, _trainData, "departing");
        TravellingState = new TrainTravellingState(this, StateMachine, _trainData, "travelling");
    }

    private void Start()
    {
        Animator = GetComponent<Animator>();

        StateMachine.Intialise(TravellingState);
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
    #endregion

    #region Other Functions
    private void AnimationTrigger() => StateMachine.CurrentState.AnimationTrigger();

    private void AnimationFinishTrigger() => StateMachine.CurrentState.AnimationFinishTrigger();

    public void SpeedDown()
    {
        // Starts speed down parallax
        _parallaxBackground = GameObject.FindGameObjectsWithTag("Parallax");
        foreach (GameObject background in _parallaxBackground)
            StartCoroutine(background.GetComponent<EasyParallax.SpriteMovement>().SpeedDownParallax());

        // Moves station
        iTween.MoveTo(_trainStation, iTween.Hash("position", new Vector3(-2f, -0.57f, 0f), "time", 10, "delay", 10, "easetype", iTween.EaseType.easeOutCubic, 
            "oncomplete", "ITweenOpenDoors", "oncompletetarget", gameObject));
    }

    public void SpeedUp()
    {
        // Starts speed up parallax
        _parallaxBackground = GameObject.FindGameObjectsWithTag("Parallax");
        foreach (GameObject background in _parallaxBackground)
            StartCoroutine(background.GetComponent<EasyParallax.SpriteMovement>().SpeedUpParallax());

        // Moves station
        iTween.MoveTo(_trainStation, iTween.Hash("position", new Vector3(-37.43f, -0.57f, 0f), "time", 10, "easetype", iTween.EaseType.easeInCubic));
    }

    public void ITweenOpenDoors()
    {
        isArrived = true;
    }
    #endregion
}