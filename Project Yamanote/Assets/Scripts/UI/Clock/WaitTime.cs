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
        [SerializeField] private Image _waitTimeProgressBar;

        private TimeSpan time;

        public int currentVal, maxValue;

        private void Start()
        {
            _waitTime.alpha = 0;
            _waitTimeProgressBar.color.a.Equals(0);
        }

        private void Update()
        {
            currentVal = (int)_timeSlider.value;           
            _waitTimeProgressBar.fillAmount = Normalise();
        }

        public void ChangeWaitTime()
        {
            _waitTime.DOFade(1, 1);

            time = TimeSpan.FromMinutes(_timeSlider.value);
            _waitTime.text = (DateTime.MinValue + time).ToString("HH:mm") + " hours";
            
            _waitTimeProgressBar.fillAmount = (float)time.TotalMinutes;
            _waitTimeProgressBar.DOFade(1, 1);
        }

        public void ClickWait()
        {
            _waitTime.DOFade(0, 1);
            
            _waitTimeProgressBar.DOFade(0, 1);

            GameClock.dateTime = GameClock.dateTime.Add(time);
        }

        private float Normalise()
        {
            return (float)currentVal / maxValue;
        }
    }
}