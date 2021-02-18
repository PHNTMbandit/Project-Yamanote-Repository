using PixelCrushers;
using UnityEngine;
using ProjectYamanote.Train;

namespace ProjectYamanote.UI.Power
{
    public class PowerButtons : MonoBehaviour
    {
        private Train train;

        public void Quit()
        {
            SaveSystem.LoadScene("MainMenu");
            SaveSystem.SaveToSlot(0);
        }
    }
}