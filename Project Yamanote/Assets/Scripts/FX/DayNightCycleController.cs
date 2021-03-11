using ProjectYamanote.Persistence;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

namespace ProjectYamanote.FX
{
    public class DayNightCycleController : MonoBehaviour
    {
        public Light2D worldLight;
        public Gradient worldLightGradient;
        public Camera gameCamera;

        [Header("Skies")]
        public SpriteRenderer dawn;
        public SpriteRenderer morning;
        public SpriteRenderer midday;
        public SpriteRenderer evening;
        public SpriteRenderer dusk;
        public SpriteRenderer midnight;
        public SpriteRenderer stars;

        private Color _dawnColour;
        private Color _morningColour;
        private Color _middayColour;
        private Color _eveningColour;
        private Color _duskColour;
        private Color _midnightColour;
        private Color _starsColour;

        [SerializeField] private AnimationCurve _dawnCurve;
        [SerializeField] private AnimationCurve _morningCurve;
        [SerializeField] private AnimationCurve _midddayCurve;
        [SerializeField] private AnimationCurve _eveningCurve;
        [SerializeField] private AnimationCurve _duskCurve;
        [SerializeField] private AnimationCurve _midnightCurve;
        [SerializeField] private GameObject[] _mapLights;

        private void Awake()
        {
            _mapLights = GameObject.FindGameObjectsWithTag("Light");
           
            dawn = dawn.GetComponent<SpriteRenderer>();
            morning = morning.GetComponent<SpriteRenderer>();
            midday = midday.GetComponent<SpriteRenderer>();
            evening = evening.GetComponent<SpriteRenderer>();
            dusk = dusk.GetComponent<SpriteRenderer>();
            midnight = midnight.GetComponent<SpriteRenderer>();
            stars = stars.GetComponent<SpriteRenderer>();

            _dawnColour = dawn.color;
            _morningColour = morning.color;
            _middayColour = midday.color;
            _eveningColour = evening.color;
            _duskColour = dusk.color;
            _midnightColour = midnight.color;
            _starsColour = stars.color;
        }

        private void Update()
        {
            #region World and local lights
            if (GameClock.dateTime.Hour >= 19 || GameClock.dateTime.Hour < 6)
                ControlLightMaps(true);
            else
                ControlLightMaps(false);

            float t = Mathf.InverseLerp(0.0f, 1440.0f, (float)GameClock.dateTime.TimeOfDay.TotalMinutes);
            worldLight.color = worldLightGradient.Evaluate(t);
            gameCamera.backgroundColor = worldLightGradient.Evaluate(t);
            #endregion

            #region Sky Transition
            _dawnColour.a = _dawnCurve.Evaluate(t);
            dawn.color = _dawnColour;

            _morningColour.a = _morningCurve.Evaluate(t);
            morning.color = _morningColour;

            _middayColour.a = _midddayCurve.Evaluate(t);
            midday.color = _middayColour;

            _eveningColour.a = _eveningCurve.Evaluate(t); ;
            evening.color = _eveningColour;

            _duskColour.a = _duskCurve.Evaluate(t);
            dusk.color = _duskColour;

            _midnightColour.a = _midnightCurve.Evaluate(t);
            midnight.color = _midnightColour;

            _starsColour.a = _midnightCurve.Evaluate(t);
            stars.color = _starsColour;
            #endregion
        }

        private void ControlLightMaps(bool status)
        {
            foreach (GameObject light in _mapLights)
                light.gameObject.SetActive(status);
        }
    }
}