using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;
using UnityEngine.UI;

public class DayNightCycle : MonoBehaviour
{
    public Light2D worldLight;
    public Gradient gradient;
    public Camera gameCamera;

    public Light2D[] mapLights;

    public void ChangeColour(float TimeInMinutes)
    {
        // Update world light
        float t = Mathf.InverseLerp(0.0f, 1440.0f, TimeInMinutes);
        worldLight.color = gradient.Evaluate(t);
        gameCamera.backgroundColor = gradient.Evaluate(t);
    }

    public void TimeBetween()
    {
        if (GameClock.dateTime.Hour >= 20 || GameClock.dateTime.Hour < 6)
            ControlLightMaps(true);
        else
            ControlLightMaps(false);
    }

    // Turn lights off or on
    private void ControlLightMaps(bool status)
    {
        if (mapLights.Length > 0)
            foreach (Light2D _light in mapLights)
                _light.gameObject.SetActive(status);
    }
}