using ProjectYamanote.UI;
using System;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

namespace ProjectYamanote.FX
{
    public class DayNightCycle : MonoBehaviour
    {
        public Light2D worldLight;
        public Gradient gradient;
        public Camera gameCamera;
        public GameObject[] mapLights;
        
        private DateTime _gameClock;
        private GameObject _gameClockGO;

        private void Awake()
        {
            _gameClockGO = GameObject.FindGameObjectWithTag("Clock");
            _gameClock = _gameClockGO.GetComponent<GameClock>().dateTime;
        }

        private void Update()
        {
            if (_gameClock.Hour >= 20 || _gameClock.Hour < 6)
                ControlLightMaps(true);
            else
                ControlLightMaps(false);

            float t = Mathf.InverseLerp(0.0f, 1440.0f, (float)_gameClock.TimeOfDay.TotalMinutes);
            worldLight.color = gradient.Evaluate(t);
            gameCamera.backgroundColor = gradient.Evaluate(t);
        }

        private void ControlLightMaps(bool status)
        {
            foreach (GameObject _light in mapLights)
                _light.gameObject.SetActive(status);
        }
    }
}