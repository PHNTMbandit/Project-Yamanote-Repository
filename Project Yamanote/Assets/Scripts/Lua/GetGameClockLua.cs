using PixelCrushers.DialogueSystem;
using ProjectYamanote.Persistence;
using UnityEngine;

public class GetGameClockLua : MonoBehaviour
{
    [Tooltip("Typically leave unticked so temporary Dialogue Managers don't unregister your functions.")]
    public bool unregisterOnDisable = false;

    public bool GetYear(double year)
    {
        return GameClock.dateTime.Year == year;
    }

    public bool GetMonth(double month)
    {
        return GameClock.dateTime.Month == month;
    }

    public bool GetDay(double day)
    {
        return GameClock.dateTime.Day == day;
    }

    public bool GetHour(double hour)
    {
        return GameClock.dateTime.Hour == hour;
    }

    public bool GetMinute(double minute)
    {
        return GameClock.dateTime.Minute == minute;
    }

    # region Register with Lua
    private void OnEnable()
    {
        Lua.RegisterFunction("GetYear", this, SymbolExtensions.GetMethodInfo(() => GetYear((double)0)));
        Lua.RegisterFunction("GetMonth", this, SymbolExtensions.GetMethodInfo(() => GetMonth((double)0)));
        Lua.RegisterFunction("GetDay", this, SymbolExtensions.GetMethodInfo(() => GetDay((double)0)));
        Lua.RegisterFunction("GetHour", this, SymbolExtensions.GetMethodInfo(() => GetHour((double)0)));
        Lua.RegisterFunction("GetMinute", this, SymbolExtensions.GetMethodInfo(() => GetMinute((double)0)));
    }

    private void OnDisable()
    {
        if (unregisterOnDisable)
        {
            Lua.UnregisterFunction("GetYear");
            Lua.UnregisterFunction("GetMonth");
            Lua.UnregisterFunction("GetDay");
            Lua.UnregisterFunction("GetHour");
            Lua.UnregisterFunction("GetMinute");
        }
    }
    #endregion
}