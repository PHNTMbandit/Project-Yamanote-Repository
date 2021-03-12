using System;
using System.Collections;
using UnityEngine;

namespace ProjectYamanote.Persistence
{
    public class GameClock : MonoBehaviour
    {
        public static int year = 2021;
        public static int month = 12;
        public static int day = 04;
        public static int hour = 23;
        public static int minute = 00;
        public static int second = 00;

        public static DateTime dateTime = new DateTime(year, month, day, hour, minute, second);

        public bool fastForwardClock;

        private void Start()
        {
            StartCoroutine(ClockCounter());
        }
        public void Update()
        {
            if (fastForwardClock == true)
                StartCoroutine(FastForwardClock());
            else
                StopCoroutine(FastForwardClock());
        }

        public IEnumerator ClockCounter()
        {
            while (second < 60)
            {
                dateTime = dateTime.AddSeconds(1);

                yield return new WaitForSeconds(1);
            }
        }

        public IEnumerator FastForwardClock()
        {
            while (fastForwardClock == true)
            {
                dateTime = dateTime.AddSeconds(1);
                print(dateTime.TimeOfDay);

                yield return null;
            }
        }

    }
}