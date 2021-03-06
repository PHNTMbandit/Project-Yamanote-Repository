using DG.Tweening;
using ProjectYamanote.Audio;
using ProjectYamanote.Persistence;
using ProjectYamanote.Train;
using ProjectYamanote.UI;
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

namespace ProjectYamanote.Station
{
    public class StationController : MonoBehaviour
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
        public bool isDeparted;
        public bool isDeparting;

        #endregion Check Variables

        #region Other Variables

        [NonSerialized] public GameObject train;
        [NonSerialized] public TrainAnnouncement trainAnnouncement;
        [SerializeField] private StationData _stationData;
        [SerializeField] private AudioManager _audioManager;
        [SerializeField] private AudioMixer _audioMixer;

        public Button saveButton;
        public Button waitTimeButton;

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
            trainAnnouncement = FindObjectOfType<TrainAnnouncement>();

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
            isDeparted = true;
            PlayerPrefs.DeleteAll();
        }

        #endregion Set Functions

        #region Other Functions

        private void AnimationTrigger() => StateMachine.CurrentState.AnimationTrigger();

        private void AnimationFinishTrigger() => StateMachine.CurrentState.AnimationFinishTrigger();

        public void TrainArriving()
        {
            foreach (var i in _stationData.trainSchedule)
            {
                if (GameClock.dateTime.TimeOfDay == i.timeArriveOriginDT.TimeOfDay)
                {
                    train.transform.DOMove(new Vector3(-20.34f, -0.03298116f, 0f), 10)
                        .SetDelay(10)
                        .SetEase(Ease.OutQuart)
                        .SetId("TrainArriving")
                        .OnComplete(TrainArrived);

                    Debug.Log(i.timeArriveDestinationDT);
                    train.GetComponent<TrainData>().SetVariables(i.origin, i.destination, i.timeArriveOriginDT, i.timeArriveDestinationDT, i.trainLine);
                }
            }
        }

        public IEnumerator TrainWaitCouroutine()
        {
            yield return new WaitForSeconds(10);

            isDeparting = true;
        }

        public void TrainDeparting()
        {
            foreach (var i in _stationData.trainSchedule)
            {
                train.transform.DOMove(new Vector3(-108f, -0.03298116f, 0f), 10)
                    .SetDelay(5)
                    .SetEase(Ease.InQuart)
                    .SetId("TrainDeparting")
                    .OnComplete(TrainDeparted);
            }
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