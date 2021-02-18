using System;
using System.Collections;
using UnityEngine;

namespace ProjectYamanote.UI
{
    public class GameClock : MonoBehaviour
    {
        public static int year = 2021;
        public static int month = 12;
        public static int day = 04;
        public static int hour = 5;
        public static int minute = 45;
        public static int second = 50;

        public static DateTime dateTime = new DateTime(year, month, day, hour, minute, second);

        private void Start()
        {
            StartCoroutine(ClockCounter());
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