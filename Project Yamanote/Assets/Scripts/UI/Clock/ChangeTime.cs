using UnityEngine;
using TMPro;
using System;

namespace ProjectYamanote.UI.Clock
{
    public class ChangeTime : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI uiClockTime;
        private DateTime gameClock;

        private void Awake()
        {
            gameClock = GetComponent<GameClock>().dateTime;
        }

        public void UpdateTime()
        {
            uiClockTime.text = gameClock.TimeOfDay.ToString("t");
        }

        public void Subtract()
        {
            gameClock = gameClock.AddHours(-1);
        }

        public void Add()
        {
            gameClock = gameClock.AddHours(1);
        }
    }
}