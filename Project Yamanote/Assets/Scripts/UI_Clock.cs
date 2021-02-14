using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;
using UnityEngine.UI;
using TMPro;

public class UI_Clock : MonoBehaviour
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
        DNC.TimeBetween();
    }

    public void Add()
    {
        GameClock.dateTime = GameClock.dateTime.AddHours(1);
        DNC.TimeBetween();
    }
}
