using UnityEngine;
using TMPro;
using ProjectYamanote.FX;

namespace ProjectYamanote.UI.Clock
{
    public class ChangeTime : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI uiClockTime;
        [SerializeField] private DayNightCycle DNC;
        [SerializeField] private GameClock gameTime;

        public void UpdateTime()
        {
            uiClockTime.text = gameTime.dateTime.ToString("t");
        }

        public void Subtract()
        {
            gameTime.dateTime = gameTime.dateTime.AddHours(-1);
            DNC.CheckTime();
        }

        public void Add()
        {
            gameTime.dateTime = gameTime.dateTime.AddHours(1);
            DNC.CheckTime();
        }
    }
}