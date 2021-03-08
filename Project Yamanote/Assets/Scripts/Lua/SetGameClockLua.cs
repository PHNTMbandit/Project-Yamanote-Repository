using UnityEngine;
using PixelCrushers.DialogueSystem;
using ProjectYamanote.Persistence;
using System;

public class SetGameClockLua : MonoBehaviour
{
    [Tooltip("Typically leave unticked so temporary Dialogue Managers don't unregister your functions.")]
    public bool unregisterOnDisable = false;

    public void SetTime(double year, double month, double day, double hour, double minute, double second)
    {
        GameClock.dateTime = new DateTime((int)year, (int)month, (int)day, (int)hour, (int)minute, (int)second);
    }

    #region Register with Lua
    private void OnEnable()
    {
        Lua.RegisterFunction("SetTime", this, SymbolExtensions.GetMethodInfo(() => SetTime((double)0, (double)0, (double)0, (double)0, (double)0, (double)0)));
    }

    private void OnDisable()
    {
        if (unregisterOnDisable)
        {
            Lua.UnregisterFunction("SetTime");
        }
    }
    #endregion
}