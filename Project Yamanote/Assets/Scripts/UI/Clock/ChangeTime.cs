using UnityEngine;
using TMPro;
using ProjectYamanote.FX;

namespace ProjectYamanote.UI.Clock
{
    public class ChangeTime : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI uiClockTime;
        [SerializeField] private DayNightCycle DNC;

        public void UpdateTime()
        {
            uiClockTime.text = GameClock.dateTime.ToString("t");
        }

        public void Subtract()
        {
            GameClock.dateTime = GameClock.dateTime.AddHours(-1);
            DNC.CheckTime();
        }

        public void Add()
        {
            GameClock.dateTime = GameClock.dateTime.AddHours(1);
            DNC.CheckTime();
        }
    }
}