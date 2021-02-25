using ProjectYamanote.Audio;
using ProjectYamanote.Train;
using ProjectYamanote.UI;
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Audio;

namespace ProjectYamanote.Station
{
    public class Station : MonoBehaviour
    {
        #region State Variables

        public StationStateMachine StateMachine { get; private set; }
        public StationArrivingState ArrivingState { get; private set; }
        public StationArrivedState ArrivedState { get; private set; }
        public StationDepartingState DepartingState { get; private set; }
        public StationDespawnState DespawnState { get; private set; }
        public StationIdleState IdleState { get; private set; }

        #endregion State Variables

        #region Components
        public Animator Animator { get; private set; }

        #endregion Components

        #region Check Variables

        public bool isArrived;
        public bool isDeparting;

        #endregion Check Variables

        #region Other Variables
        public Transform arrivalPosition;
        public Transform instantiatePosition;
        public Transform despawnPosition;

        [NonSerialized] public GameObject train;
        
        [SerializeField] private StationData _stationData;
        [SerializeField] private AudioManager _audioManager;
        [SerializeField] private AudioMixer _audioMixer;
        #endregion Other Variables

        #region Unity Callback Functions

        private void Awake()
        {
            StateMachine = new StationStateMachine();

            ArrivingState = new StationArrivingState(this, StateMachine, _stationData, "arriving");
            ArrivedState = new StationArrivedState(this, StateMachine, _stationData, "arrived");
            IdleState = new StationIdleState(this, StateMachine, _stationData, "idle");
            DepartingState = new StationDepartingState(this, StateMachine, _stationData, "departing");
            DespawnState = new StationDespawnState(this, StateMachine, _stationData, "despawn");
        }

        private void Start()
        {
            foreach (var i in _stationData.trainSchedule)
            {
                train = i.trainPrefab;
            }

            Animator = train.GetComponentInChildren<Animator>();

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

        #endregion Unity Callback Functions

        #region Set Functions
        public void TrainArrived()
        {
            isArrived = true;
        }

        public void TrainDeparted()
        {
            isDeparting = false;
        }

        #endregion Set Functions

        #region Check Functions

        #endregion Check Functions

        #region Other Functions

        private void AnimationTrigger() => StateMachine.CurrentState.AnimationTrigger();

        private void AnimationFinishTrigger() => StateMachine.CurrentState.AnimationFinishTrigger();

        public void TrainArriving()
        {
            foreach (var i in _stationData.trainSchedule)
            {
                iTween.MoveTo(train, iTween.Hash("position", arrivalPosition.position, "time", 10, "delay", 10,
                    "easetype", iTween.EaseType.easeOutCubic, "oncomplete", "TrainArrived", "oncompletetarget", gameObject));

                train.GetComponent<TrainData>().SetVariables(i.origin, i.destination, i.timeArriveOriginDT, i.timeArriveDestinationDT, i.trainLine);
            }
        }

        public IEnumerator TrainArrivedCouroutine()
        {
            yield return new WaitForSeconds(10);

            isDeparting = true;
        }

        public IEnumerator TrainDepartingCouroutine()
        {
            isArrived = false;

            iTween.MoveTo(train, iTween.Hash("position", despawnPosition.position, "time", 10, "delay", 5,
                "easetype", iTween.EaseType.easeInCubic, "oncomplete", "TrainDeparted", "oncompletetarget", gameObject));

            yield return null;
        }
        #endregion Other Functions

        #region SFX Functions

        public void TrainArrivingSFX()
        {
            _audioManager.Play("TrainArriving");
            StartCoroutine(FadeMixerGroup.StartFade(_audioMixer, "TrainArriving", 2f, 1f));
        }

        public void TrainArrivedSFX()
        {
            _audioManager.Play("TrainArrived");
            StartCoroutine(FadeMixerGroup.StartFade(_audioMixer, "TrainArrived", 2f, 1f));

            StartCoroutine(FadeMixerGroup.StartFade(_audioMixer, "TrainArriving", 2f, 0f));
        }

        public void TrainDepartingSFX()
        {
            _audioManager.Play("TrainDeparting");
            _audioManager.Play("DoorsClosing");
            StartCoroutine(FadeMixerGroup.StartFade(_audioMixer, "TrainDeparting", 2f, 1f));

            StartCoroutine(FadeMixerGroup.StartFade(_audioMixer, "TrainArrived", 2f, 0f));
        }

        public void TrainDespawnSFX()
        {
            StartCoroutine(FadeMixerGroup.StartFade(_audioMixer, "TrainDeparting", 2f, 0f));
        }

        #endregion SFX Functions
    }
}