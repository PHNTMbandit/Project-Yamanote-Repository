using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;
using UnityEngine.UI;
using TMPro;

public class GameClock : MonoBehaviour
{
    // Starting date and time
    [Header("Calendar")]
    public static int year = 2021;
    public static int month = 12;
    public static int day = 04;

    [Header("Time")]
    public static int hour = 23;
    public static int minute = 59;
    public static int second = 50;

    // In-game calendar and time
    public static DateTime dateTime = new DateTime(year, month, day, hour, minute, second);

    [Header("Declarables")]
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
        // Update DayNightCycle and lights
        DNC.ChangeColour((float)dateTime.TimeOfDay.TotalMinutes);
        DNC.TimeBetween();

        // Update clock texts
        phoneTime.text = dateTime.ToString("t");
        actionBarTime.text = dateTime.ToString("t");
        phoneDate.text = dateTime.ToString("dddd, dd MMM yyyy");
        actionBarDate.text = dateTime.ToString("dddd, dd MMM yyyy");
    }

    private void UpdateStats()
    {
        // Remove hunger and energy
        energyBar.RemoveEnergy(playerData.energyBarSpendRate);
        hungerBar.RemoveHunger(playerData.hungerBarSpendRate);
    }
}
