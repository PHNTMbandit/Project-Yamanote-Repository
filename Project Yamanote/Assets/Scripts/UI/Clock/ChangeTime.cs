using UnityEngine;
using TMPro;

namespace ProjectYamanote.UI.Clock
{
    public class ChangeTime : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI uiClockTime;

        public void UpdateTime()
        {
            uiClockTime.text = GameClock.dateTime.TimeOfDay.ToString("t");
        }

        public void Subtract()
        {
            GameClock.dateTime = GameClock.dateTime.AddHours(-1);
        }

        public void Add()
        {
            GameClock.dateTime = GameClock.dateTime.AddHours(1);
        }
    }
}