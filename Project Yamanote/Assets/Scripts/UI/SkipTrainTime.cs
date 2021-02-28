using DG.Tweening;
using ProjectYamanote.Train;
using ProjectYamanote.UI;
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace ProjectYamanote
{
    public class SkipTrainTime : MonoBehaviour
    {
        public GameObject buttonGO;
        public Animator fadeAnimator;
        public TrainController trainController;

        private Button button;

        private void Start()
        {
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
            GameClock.dateTime = new DateTime(TrainData.timeArriveDestinationDT.Ticks);
            fadeAnimator.SetTrigger("Hide");
        }
    }
}