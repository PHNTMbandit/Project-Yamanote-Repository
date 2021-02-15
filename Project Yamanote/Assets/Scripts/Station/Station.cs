using ProjectYamanote.Audio;
using ProjectYamanote.ScriptableObjects;
using ProjectYamanote.Station.States;
using ProjectYamanote.Station.States.SubStates;
using ProjectYamanote.Train;
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
        #endregion

        #region Components
        public Animator Animator { get; private set; }
        #endregion

        #region Check Variables
        public bool isArrived;
        public bool isDeparting;
        #endregion

        #region Other Variables
        public GameTime gameTime;

        [SerializeField] private StationData _stationData;
        [SerializeField] private Transform _arrivalPosition;
        [SerializeField] private Transform _instantiatePosition;
        [SerializeField] private Transform _despawnPosition;
        [SerializeField] private GameObject _train;
        [SerializeField] private AudioManager _audioManager;
        [SerializeField] private AudioMixer _audioMixer;
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

            StateMachine.Initialise(ArrivedState);
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
        public void TrainStart()
        {
            isDeparting = true;
        }
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

        public void TrainArriving()
        {
            foreach (var i in _stationData.trainSchedule)
            {
                iTween.MoveTo(_train, iTween.Hash("position", _arrivalPosition.position, "time", 10, "delay", 10,
                    "easetype", iTween.EaseType.easeOutCubic, "oncomplete", "TrainArrived", "oncompletetarget", gameObject));

                _train.GetComponent<TrainData>().SetVariables(i.origin, i.destination, i.timeArriveOriginDT, i.timeArriveDestinationDT);
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

            iTween.MoveTo(_train, iTween.Hash("position", _despawnPosition.position, "time", 10, "delay", 5,
                "easetype", iTween.EaseType.easeInCubic, "oncomplete", "TrainDeparted", "oncompletetarget", gameObject));

            yield return null;
        }

        public void TrainReset()
        {
            _train.transform.position = _instantiatePosition.position;
        }
        #endregion

        #region SFX Functions
        public void TrainArrivingSFX()
        {
            _audioManager.Play("TrainArriving");
            StartCoroutine(FadeMixerGroup.StartFade(_audioMixer, "TrainArriving", 2f, 1f));

            StartCoroutine(FadeMixerGroup.StartFade(_audioMixer, "TrainDespawn", 2f, 0f));
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
            _audioManager.Play("TrainDespawn");
            StartCoroutine(FadeMixerGroup.StartFade(_audioMixer, "TrainDespawn", 2f, 1f));

            StartCoroutine(FadeMixerGroup.StartFade(_audioMixer, "TrainDeparting", 2f, 0f));
        }
        #endregion
    }
}

