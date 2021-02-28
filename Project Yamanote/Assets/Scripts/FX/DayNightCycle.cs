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
        [SerializeField] private GameObject[] mapLights;

        private void Start()
        {
            mapLights = GameObject.FindGameObjectsWithTag("Light");
        }

        private void Update()
        {
            if (GameClock.dateTime.Hour >= 19 || GameClock.dateTime.Hour < 6)
                ControlLightMaps(true);
            else
                ControlLightMaps(false);

            float t = Mathf.InverseLerp(0.0f, 1440.0f, (float)GameClock.dateTime.TimeOfDay.TotalMinutes);
            worldLight.color = gradient.Evaluate(t);
            gameCamera.backgroundColor = gradient.Evaluate(t);
        }

        private void ControlLightMaps(bool status)
        {
            foreach (GameObject light in mapLights)
                light.gameObject.SetActive(status);
        }
    }
}