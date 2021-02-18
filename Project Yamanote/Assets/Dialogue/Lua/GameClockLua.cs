using UnityEngine;
using PixelCrushers.DialogueSystem;
using ProjectYamanote.UI;
using System;

public class GameClockLua : MonoBehaviour
{
    [Tooltip("Typically leave unticked so temporary Dialogue Managers don't unregister your functions.")]
    public bool unregisterOnDisable = false;

    private DateTime _gameClock;
    private GameObject _gameClockGO;

    private void Awake()
    {
        _gameClockGO = GameObject.FindGameObjectWithTag("Clock");
        _gameClock = _gameClockGO.GetComponent<GameClock>().dateTime;
    }

    public bool Year(double year)
    {
        return _gameClock.Year == year;
    }

    public bool Month(double month)
    {
        return _gameClock.Month== month;
    }

    public bool Day(double day)
    {
        return _gameClock.Day == day;
    }

    public bool Hour(double hour)
    {
        return _gameClock.Hour == hour;
    }

    public bool Minute(double minute)
    {
        return _gameClock.Minute == minute;
    }

    # region Register with Lua
    void OnEnable()
    {
        // Make the functions available to Lua: (Replace these lines with your own.)
        Lua.RegisterFunction("Year", this, SymbolExtensions.GetMethodInfo(() => Year((double)0)));
        Lua.RegisterFunction("Month", this, SymbolExtensions.GetMethodInfo(() => Month((double)0)));
        Lua.RegisterFunction("Day", this, SymbolExtensions.GetMethodInfo(() => Day((double)0)));
        Lua.RegisterFunction("Hour", this, SymbolExtensions.GetMethodInfo(() => Hour((double)0)));
        Lua.RegisterFunction("Minute", this, SymbolExtensions.GetMethodInfo(() => Minute((double)0)));
    }

    void OnDisable()
    {
        if (unregisterOnDisable)
        {
            // Remove the functions from Lua: (Replace these lines with your own.)
            Lua.UnregisterFunction("Year");
            Lua.UnregisterFunction("Month");
            Lua.UnregisterFunction("Day");
            Lua.UnregisterFunction("Hour");
            Lua.UnregisterFunction("Minute");
        }
    }
    #endregion
}
