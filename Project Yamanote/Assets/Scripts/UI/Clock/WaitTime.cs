using DG.Tweening;
using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

namespace ProjectYamanote.UI
{
    public class WaitTime : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _waitTime;
        [SerializeField] private Slider _timeSlider;
        [SerializeField] private Image _waitTimeProgressBar;
        [SerializeField] private Button _waitTimeButton;
        [SerializeField] private GameObject _tooltip;

        private TimeSpan time;

        public int currentVal, maxValue;

        private void Start()
        {
            _waitTime.alpha = 0;
            _waitTimeProgressBar.DOFade(0, 0.1f);
        }

        private void Update()
        {
            currentVal = (int)((int)GameClock.dateTime.TimeOfDay.TotalMinutes + _timeSlider.value);

            _waitTimeProgressBar.fillAmount = Normalise();

            if (_waitTimeButton.interactable == false)
                _tooltip.SetActive(true);
            else
                _tooltip.SetActive(false);
        }

        public void ChangeWaitTime()
        {
            _waitTime.DOFade(1, 1);
            _waitTimeProgressBar.DOFade(1, 1);

            time = TimeSpan.FromMinutes(_timeSlider.value);
            _waitTime.text = (DateTime.MinValue + time).ToString("HH:mm") + " hours";
        }

        public void ClickWait()
        {
            _waitTime.DOFade(0, 1);
            _waitTimeProgressBar.DOFade(0, 1);

            GameClock.dateTime = GameClock.dateTime.AddMinutes(time.TotalMinutes);
            _timeSlider.value = 0;
        }

        private float Normalise()
        {
            return (float)currentVal / maxValue;
        }
    }
}