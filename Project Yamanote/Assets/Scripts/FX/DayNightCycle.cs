using ProjectYamanote.UI;
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
        public GameClock gameTime;

        private GameClock _gameClock;

        private void Start()
        {
            _gameClock = FindObjectOfType<GameClock>();
        }

        public void ChangeColour(float TimeInMinutes)
        {
            float t = Mathf.InverseLerp(0.0f, 1440.0f, (float)_gameClock.dateTime.TimeOfDay.TotalMinutes);
            worldLight.color = gradient.Evaluate(t);
            gameCamera.backgroundColor = gradient.Evaluate(t);
        }

        public void CheckTime()
        {
            if (_gameClock.dateTime.Hour >= 20 || _gameClock.dateTime.Hour < 6)
                ControlLightMaps(true);
            else
                ControlLightMaps(false);
        }

        private void ControlLightMaps(bool status)
        {
            mapLights = GameObject.FindGameObjectsWithTag("Light");
            if (mapLights.Length > 0)
                foreach (GameObject _light in mapLights)
                    _light.gameObject.SetActive(status);
        }
    }
}