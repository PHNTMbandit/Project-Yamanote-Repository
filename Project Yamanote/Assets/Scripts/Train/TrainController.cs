using DG.Tweening;
using ProjectYamanote.Audio;
using ProjectYamanote.UI;
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

namespace ProjectYamanote.Train
{
    public class TrainController : MonoBehaviour
    {
        #region State Variables

        public TrainStateMachine StateMachine { get; set; }
        public TrainArrivedState ArrivedState { get; set; }
        public TrainIdleState IdleState { get; set; }
        public TrainArrivingState ArrivingState { get; set; }
        public TrainDepartingState DepartingState { get; set; }
        public TrainTravellingState TravellingState { get; set; }

        #endregion State Variables

        #region Components
        public Animator Animator { get; private set; }
        #endregion Components

        #region Check Variables
        public bool isArrived;
        public bool isDeparted;
        #endregion Check Variables

        #region Other Variables

        [Header("Public Fields")]
        public TrainData trainData;
        public Button waitTimeButton;
        public Button saveButton;
        public GameObject skipButton;
        public GameObject _stationForeground;
        public GameObject _stationBackground;
        public Camera playerCamera;

        [NonSerialized] public TrainAnnouncement trainAnnouncement;

        [SerializeField] private GameObject[] _parallaxBackground;
        [SerializeField] private AudioManager audioManager;
        [SerializeField] private AudioMixer audioMixer;

        private SkipTrainTime skipTrain;

        #endregion Other Variables

        #region Unity Callback Functions

        private void Awake()
        {
            StateMachine = new TrainStateMachine();

            ArrivedState = new TrainArrivedState(this, StateMachine, trainData, "arrived");
            IdleState = new TrainIdleState(this, StateMachine, trainData, "idle");
            ArrivingState = new TrainArrivingState(this, StateMachine, trainData, "arriving");
            DepartingState = new TrainDepartingState(this, StateMachine, trainData, "departing");
            TravellingState = new TrainTravellingState(this, StateMachine, trainData, "travelling");
        }

        private void Start()
        {
            Animator = GetComponent<Animator>();
            trainAnnouncement = FindObjectOfType<TrainAnnouncement>();
            skipTrain = FindObjectOfType<SkipTrainTime>();

            waitTimeButton.interactable = false;

            StateMachine.Intialise(IdleState);

            InvokeRepeating("HandleShake", 0, 30);
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

        public void TrainDeparted()
        {
            isDeparted = false;
        }

        public void TrainArrived()
        {
            isArrived = true;
        }

        #endregion Set Functions

        #region Other Functions

        private void AnimationTrigger() => StateMachine.CurrentState.AnimationTrigger();

        private void AnimationFinishTrigger() => StateMachine.CurrentState.AnimationFinishTrigger();

        public void SpeedDown()
        {
            _parallaxBackground = GameObject.FindGameObjectsWithTag("Parallax");
            foreach (GameObject background in _parallaxBackground)
            {
                StopCoroutine(background.GetComponent<EasyParallax.SpriteMovement>().SpeedUpParallax());
                StartCoroutine(background.GetComponent<EasyParallax.SpriteMovement>().SpeedDownParallax());
            }
            _stationForeground.transform.DOMove(new Vector3(10.38f, -7.706331f, 0f), 10)
                    .SetDelay(10)
                    .SetEase(Ease.OutQuart)
                    .OnComplete(TrainArrived);

            _stationBackground.transform.DOMove(new Vector3(10.38f, -7.325131f, 0f), 10)
                    .SetDelay(10)
                    .SetEase(Ease.OutQuart);
        }

        public void SpeedUp()
        {
            _parallaxBackground = GameObject.FindGameObjectsWithTag("Parallax");
            foreach (GameObject background in _parallaxBackground)
            {
                StartCoroutine(background.GetComponent<EasyParallax.SpriteMovement>().SpeedUpParallax());
                StopCoroutine(background.GetComponent<EasyParallax.SpriteMovement>().SpeedDownParallax());
            }

            _stationForeground.transform.DOMove(new Vector3(-51.4f, -7.706331f, 0f), 15)
                    .SetEase(Ease.InCubic)
                    .SetDelay(5)
                    .OnComplete(TrainDeparted);

            _stationBackground.transform.DOMove(new Vector3(-51.4f, -7.325131f, 0f), 15)
                    .SetEase(Ease.InCubic)
                    .SetDelay(5);
        }

        public IEnumerator TrainArrivedCouroutine()
        {
            _parallaxBackground = GameObject.FindGameObjectsWithTag("Parallax");
            foreach (GameObject background in _parallaxBackground)
            {
                background.GetComponent<EasyParallax.SpriteMovement>().Stop();
            }

            yield return new WaitForSeconds(10);

            isDeparted = true;
        }

        public void HandleShake()
        {
            if (StateMachine.CurrentState == TravellingState)
            {
                playerCamera.DOShakePosition(1);
                Animator.SetTrigger("shake");
            }
        }

        #endregion Other Functions

        #region SFX Functions

        public void TrainArrivingSFX()
        {
            audioManager.Play("TrainArriving");
            StartCoroutine(FadeMixerGroup.StartFade(audioMixer, "TrainArriving", 2f, 1f));

            StartCoroutine(FadeMixerGroup.StartFade(audioMixer, "TrainTravelling", 2f, 0f));
            StartCoroutine(FadeMixerGroup.StartFade(audioMixer, "Music", 5f, 0f));
        }

        public void TrainArrivedSFX()
        {
            audioManager.Play("TrainArrived");
            StartCoroutine(FadeMixerGroup.StartFade(audioMixer, "TrainArrived", 2f, 1f));

            StartCoroutine(FadeMixerGroup.StartFade(audioMixer, "TrainArriving", 2f, 0f));
            StartCoroutine(FadeMixerGroup.StartFade(audioMixer, "Music", 1f, 0f));
        }

        public void TrainIdleSFX()
        {
            StartCoroutine(FadeMixerGroup.StartFade(audioMixer, "StationAmbiance", 3f, 1f));
        }

        public void TrainDepartingSFX()
        {
            audioManager.Play("TrainDeparting");
            audioManager.Play("DoorsClosing");
            StartCoroutine(FadeMixerGroup.StartFade(audioMixer, "TrainDeparting", 2f, 1f));

            StartCoroutine(FadeMixerGroup.StartFade(audioMixer, "TrainArrived", 2f, 0f));
            StartCoroutine(FadeMixerGroup.StartFade(audioMixer, "StationAmbiance", 2f, 0f));
        }

        public void TrainTravellingSFX()
        {
            audioManager.Play("TrainTravelling");
            audioManager.Play("Music");
            StartCoroutine(FadeMixerGroup.StartFade(audioMixer, "TrainTravelling", 2f, 1f));
            StartCoroutine(FadeMixerGroup.StartFade(audioMixer, "Music", 5f, 1f));

            StartCoroutine(FadeMixerGroup.StartFade(audioMixer, "TrainDeparting", 2f, 0f));
        }

        #endregion SFX Functions
    }
}