using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace ProjectYamanote.UI
{
    public class RadialClock : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _clockTime;
        [SerializeField] private TextMeshProUGUI _clockDate;
        [SerializeField] private Image _clockTimeProgressBar;

        public int currentVal, maxValue;

        private void Update()
        {
            _clockTimeProgressBar.fillAmount = Normalise();
            _clockTime.text = GameClock.dateTime.ToString("t");
            _clockDate.text = GameClock.dateTime.ToString("D");
            currentVal = (int)GameClock.dateTime.TimeOfDay.TotalMinutes;
        }

        private float Normalise()
        {
            return (float)currentVal / maxValue;
        }
    }
}