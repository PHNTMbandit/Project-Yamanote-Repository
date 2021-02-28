using ProjectYamanote.Persistence;
using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace ProjectYamanote.UI
{
    public class Calendar : MonoBehaviour
    {
        public class Day
        {
            public int dayNum;
            public Color dayColor;
            public Color enabledColor = new Color(0.8901961f, 0.8901961f, 0.8901961f, 1);
            public GameObject obj;

            public Day(int dayNum, Color dayColor, GameObject obj)
            {
                this.dayNum = dayNum;
                this.obj = obj;
                UpdateColor(dayColor);
                UpdateDay(dayNum);
            }

            public void UpdateColor(Color newColor)
            {
                obj.GetComponentInChildren<TextMeshProUGUI>().color = newColor;
                dayColor = newColor;
            }

            public void UpdateDay(int newDayNum)
            {
                this.dayNum = newDayNum;
                if (dayColor == enabledColor || dayColor == Color.red)
                {
                    obj.GetComponentInChildren<TextMeshProUGUI>().text = (dayNum + 1).ToString();
                }
                else
                {
                    obj.GetComponentInChildren<TextMeshProUGUI>().text = "";
                }
            }
        }

        private List<Day> days = new List<Day>();

        public Transform[] weeks;

        public TextMeshProUGUI Month;
        public TextMeshProUGUI Year;

        public Color enabledColour;
        public Color todayColour;

        public DateTime currDate = GameClock.dateTime;

        private void Start()
        {
            UpdateCalendar(GameClock.dateTime.Year, GameClock.dateTime.Month);
        }

        private void UpdateCalendar(int year, int month)
        {
            DateTime temp = new DateTime(year, month, 1);
            currDate = temp;
            Month.text = temp.ToString("MMMM");
            Year.text = temp.Year.ToString();
            int startDay = GetMonthStartDay(year, month);
            int endDay = GetTotalNumberOfDays(year, month);

            if (days.Count == 0)
            {
                for (int w = 0; w < 6; w++)
                {
                    for (int i = 0; i < 7; i++)
                    {
                        Day newDay;
                        int currDay = (w * 7) + i;
                        if (currDay < startDay || currDay - startDay >= endDay)
                        {
                            newDay = new Day(currDay - startDay, Color.clear, weeks[w].GetChild(i).gameObject);
                        }
                        else
                        {
                            newDay = new Day(currDay - startDay, enabledColour, weeks[w].GetChild(i).gameObject);
                        }
                        days.Add(newDay);
                    }
                }
            }
            else
            {
                for (int i = 0; i < 42; i++)
                {
                    if (i < startDay || i - startDay >= endDay)
                    {
                        days[i].UpdateColor(Color.clear);
                    }
                    else
                    {
                        days[i].UpdateColor(enabledColour);
                    }

                    days[i].UpdateDay(i - startDay);
                }
            }

            if (GameClock.dateTime.Year == year && GameClock.dateTime.Month == month)
            {
                days[(GameClock.dateTime.Day - 1) + startDay].UpdateColor(Color.red);
            }
        }

        private int GetMonthStartDay(int year, int month)
        {
            DateTime temp = new DateTime(year, month, 1);

            return (int)temp.DayOfWeek;
        }

        private int GetTotalNumberOfDays(int year, int month)
        {
            return DateTime.DaysInMonth(year, month);
        }

        public void SwitchMonth(int direction)
        {
            if (direction < 0)
            {
                currDate = currDate.AddMonths(-1);
            }
            else
            {
                currDate = currDate.AddMonths(1);
            }

            UpdateCalendar(currDate.Year, currDate.Month);
        }
    }
}