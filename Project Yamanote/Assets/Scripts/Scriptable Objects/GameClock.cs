using System.Collections;
using System;
using UnityEngine;
using TMPro;
using ProjectYamanote.UI.Clock;
using ProjectYamanote.FX;
using ProjectYamanote.Player;

namespace ProjectYamanote.ScriptableObjects
{
    public class GameClock : MonoBehaviour
    {
        public static int year = 2021;
        public static int month = 12;
        public static int day = 04;
        public static int hour = 17;
        public static int minute = 29;
        public static int second = 50;

        public static DateTime dateTime = new DateTime(year, month, day, hour, minute, second);

        public ChangeTime uiClock;
        public DayNightCycle DNC;
        public EnergyBar energyBar;
        public HungerBar hungerBar;
        public PlayerData playerData;
        public TextMeshProUGUI phoneTime;
        public TextMeshProUGUI phoneDate;
        public TextMeshProUGUI actionBarTime;
        public TextMeshProUGUI actionBarDate;

        void Start()
        {
            StartCoroutine(SecondTimer());
            UpdateVariables();
        }

        // Adds a second to the in-game clock
        private IEnumerator SecondTimer()
        {
            while (dateTime.Second <= 60)
            {
                dateTime = dateTime.AddSeconds(1);
                UpdateVariables();
                UpdateStats();

                yield return new WaitForSeconds(1);
            }
        }

        private void UpdateVariables()
        {
            DNC.ChangeColour((float)dateTime.TimeOfDay.TotalMinutes);
            DNC.CheckTime();
            uiClock.UpdateTime();

            phoneTime.text = dateTime.ToString("t");
            actionBarTime.text = dateTime.ToString("t");
            phoneDate.text = dateTime.ToString("dddd, dd MMM yyyy");
            actionBarDate.text = dateTime.ToString("dddd, dd MMM yyyy");
        }

        private void UpdateStats()
        {
            energyBar.RemoveEnergy(playerData.energyBarSpendRate);
            hungerBar.RemoveHunger(playerData.hungerBarSpendRate);
        }
    }
}