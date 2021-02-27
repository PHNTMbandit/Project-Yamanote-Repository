using DG.Tweening;
using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace ProjectYamanote.UI
{
    public class WaitTime : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _waitTime;
        [SerializeField] private Slider _timeSlider;

        private TimeSpan time;

        private void Start()
        {
            _waitTime.alpha = 0;
        }

        public void ChangeWaitTimeText()
        {
            _waitTime.DOFade(1, 1);
            time = TimeSpan.FromMinutes(_timeSlider.value);
            _waitTime.text = (DateTime.MinValue + time).ToString("HH:mm") + " hours";
        }

        public void ClickWait()
        {
            _waitTime.DOFade(0, 1);
            GameClock.dateTime = GameClock.dateTime.Add(time);
        }
    }
}