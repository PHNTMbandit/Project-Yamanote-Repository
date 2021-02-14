using UnityEngine;
using PixelCrushers.DialogueSystem;

public class GameClockLua : MonoBehaviour
{
    [Tooltip("Typically leave unticked so temporary Dialogue Managers don't unregister your functions.")]
    public bool unregisterOnDisable = false;

    public bool Year(double year)
    {
        return GameClock.dateTime.Year == year;
    }

    public bool Month(double month)
    {
        return GameClock.dateTime.Month== month;
    }

    public bool Day(double day)
    {
        return GameClock.dateTime.Day == day;
    }

    public bool Hour(double hour)
    {
        return GameClock.dateTime.Hour == hour;
    }

    public bool Minute(double minute)
    {
        return GameClock.dateTime.Minute == minute;
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
