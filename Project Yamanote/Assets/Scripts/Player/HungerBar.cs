using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace ProjectYamanote.Player
{
    public class HungerBar : MonoBehaviour
    {
        public Slider slider;
        public Gradient gradient;
        public Image fill;
        public PlayerData playerData;

        private void Start()
        {
            StartCoroutine(SpendHunger());
        }

        public void SetMaxHunger(float hunger)
        {
            slider.maxValue = hunger;
            slider.value = hunger;

            fill.color = gradient.Evaluate(1f);
        }

        public void SetHunger(float hunger)
        {
            slider.value = hunger;

            fill.color = gradient.Evaluate(slider.normalizedValue);
        }

        public void RemoveHunger(float hunger)
        {
            slider.value -= hunger;

            fill.color = gradient.Evaluate(slider.normalizedValue);
        }

        public IEnumerator SpendHunger()
        {
            while (slider.value > 0)
            {
                RemoveHunger(playerData.hungerBarSpendRate);

                yield return new WaitForSeconds(1);
            }

            Debug.Log("Game Over");
        }
    }
}