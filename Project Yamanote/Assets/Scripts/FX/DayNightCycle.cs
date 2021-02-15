using ProjectYamanote.ScriptableObjects;
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
        public GameTime gameTime;

        public void ChangeColour(float TimeInMinutes)
        {
            float t = Mathf.InverseLerp(0.0f, 1440.0f, TimeInMinutes);
            worldLight.color = gradient.Evaluate(t);
            gameCamera.backgroundColor = gradient.Evaluate(t);
        }

        public void CheckTime()
        {
            if (gameTime.dateTime.Hour >= 20 || gameTime.dateTime.Hour < 6)
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