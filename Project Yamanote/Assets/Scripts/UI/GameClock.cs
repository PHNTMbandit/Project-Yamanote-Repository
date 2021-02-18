using System;
using System.Collections;
using UnityEngine;

namespace ProjectYamanote.UI
{
    public class GameClock : MonoBehaviour
    {
        public int year = 2021;
        public int month = 12;
        public int day = 04;
        public int hour = 5;
        public int minute = 45;
        public int second = 50;

        public DateTime dateTime;

        private void Start()
        {
            StartCoroutine(ClockCounter());
            dateTime = new DateTime(year, month, day, hour, minute, second);
        }

        public IEnumerator ClockCounter()
        {
            while (second < 60)
            {
                dateTime = dateTime.AddSeconds(1);

                yield return new WaitForSeconds(1);
            }
        }
    }
}