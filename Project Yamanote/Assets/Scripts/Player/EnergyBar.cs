using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace ProjectYamanote.Player
{
    public class EnergyBar : MonoBehaviour
    {
        public Slider slider;
        public Gradient gradient;
        public Image fill;
        public PlayerData playerData;

        private void Start()
        {
            StartCoroutine(SpendEnergy());
        }

        public void SetMaxEnergy(float energy)
        {
            slider.maxValue = energy;
            slider.value = energy;

            fill.color = gradient.Evaluate(1f);
        }

        public void SetEnergy(float energy)
        {
            slider.value = energy;

            fill.color = gradient.Evaluate(slider.normalizedValue);
        }

        public void RemoveEnergy(float energy)
        {
            slider.value -= energy;

            fill.color = gradient.Evaluate(slider.normalizedValue);
        }

        public IEnumerator SpendEnergy()
        {
            while (slider.value > 0)
            {
                RemoveEnergy(playerData.energyBarSpendRate);

                yield return new WaitForSeconds(1);
            }

            Debug.Log("Game Over");
        }
    }
}
