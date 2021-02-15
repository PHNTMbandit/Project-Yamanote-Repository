using PixelCrushers;
using UnityEngine;

namespace ProjectYamanote.UI.Power
{
    public class PowerButtons : MonoBehaviour
    {
        public void Quit()
        {
            SaveSystem.LoadScene("MainMenu");
            SaveSystem.SaveToSlot(0);
        }
    }
}