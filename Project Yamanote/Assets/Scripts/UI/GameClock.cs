using System;
using System.Collections;
using UnityEngine;

namespace ProjectYamanote.UI
{
    public class GameClock : MonoBehaviour
    {
        public int year;
        public int month;
        public int day;
        public int hour;
        public int minute;
        public int second;

        public static DateTime dateTime;

        private void Start()
        {
            dateTime = new DateTime(year, month, day, hour, minute, second);
            StartCoroutine(ClockCounter());
        }

        public IEnumerator ClockCounter()
        {
            while (second < 60)
            {
                dateTime = dateTime.AddSeconds(1);
                Debug.Log(dateTime);
                yield return new WaitForSeconds(1);
            }
        }
    }
}