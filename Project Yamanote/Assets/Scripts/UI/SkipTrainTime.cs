using DG.Tweening;
using ProjectYamanote.Persistence;
using ProjectYamanote.Train;
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace ProjectYamanote
{
    public class SkipTrainTime : MonoBehaviour
    {
        public GameObject buttonGO;
        public TrainController trainController;

        private Button button;
        private Animator fadeAnimator;
        private GameObject sceneFader;

        private void Start()
        {
            sceneFader = GameObject.FindGameObjectWithTag("SceneFader");
            fadeAnimator = sceneFader.GetComponent<Animator>();
            button = buttonGO.GetComponent<Button>();
            buttonGO.SetActive(false);
            button.image.DOFade(0, 0.1f);
        }

        public void StartSkipCouroutine()
        {
            StartCoroutine((SkipCouroutine()));
        }

        public IEnumerator SkipCouroutine()
        {
            fadeAnimator.SetTrigger("Show");

            yield return new WaitForSeconds(2);

            trainController.StateMachine.ChangeState(trainController.ArrivingState);
            GameClock.dateTime = new DateTime(TrainData.timeArriveDestinationDT.TimeOfDay.Ticks);
            fadeAnimator.SetTrigger("Hide");
        }
    }
}