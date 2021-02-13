using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

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
    public bool isDeparted;
    #endregion

    #region Other Variables
    [SerializeField] private GameObject[] _parallaxBackground;
    [SerializeField] private AudioManager audioManager;
    [SerializeField] private AudioMixer audioMixer;
    public Transform departTransform;
    public Transform arrivedTransfrom;
    public Transform arrivingTransform;

    public TrainData trainData;
    public GameObject trainStation;
    #endregion

    #region Unity Callback Functions
    private void Awake()
    {
        StateMachine = new TrainStateMachine();

        ArrivedState = new TrainArrivedState(this, StateMachine, trainData, "arrived");
        ArrivingState = new TrainArrivingState(this, StateMachine, trainData, "arriving");
        DepartingState = new TrainDepartingState(this, StateMachine, trainData, "departing");
        TravellingState = new TrainTravellingState(this, StateMachine, trainData, "travelling");
    }

    private void Start()
    {
        Animator = GetComponent<Animator>();

        StateMachine.Intialise(ArrivedState);

        print(TrainData.timeArriveDestinationDT.TimeOfDay);
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
    public void TrainDeparted()
    {
        isDeparted = false;

        trainStation.transform.position = arrivingTransform.position;
    }

    public void TrainArrived()
    {
        isArrived = true;
    }
    #endregion

    #region Check Functions
    #endregion

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

        iTween.MoveTo(trainStation, iTween.Hash("position", arrivedTransfrom.position, "time", 6, "delay", 10, "easetype", iTween.EaseType.easeOutCubic, 
            "oncomplete", "TrainArrived", "oncompletetarget", gameObject));
    }

    public void SpeedUp()
    {
        _parallaxBackground = GameObject.FindGameObjectsWithTag("Parallax");
        foreach (GameObject background in _parallaxBackground)
        {
            StartCoroutine(background.GetComponent<EasyParallax.SpriteMovement>().SpeedUpParallax());
            StopCoroutine(background.GetComponent<EasyParallax.SpriteMovement>().SpeedDownParallax());
        }

        iTween.MoveTo(trainStation, iTween.Hash("position", departTransform.position, "time", 10, "easetype", iTween.EaseType.easeInCubic, 
            "oncomplete", "TrainDeparted", "oncompletetarget", gameObject));
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
    #endregion

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
        StartCoroutine(FadeMixerGroup.StartFade(audioMixer, "StationAmbiance", 3f, 1f));

        StartCoroutine(FadeMixerGroup.StartFade(audioMixer, "TrainArriving", 2f, 0f));
        StartCoroutine(FadeMixerGroup.StartFade(audioMixer, "Music", 1f, 0f));
    }

    public void TrainDepartingSFX()
    {
        audioManager.Play("TrainDeparting");
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
    #endregion
}