using PixelCrushers;
using UnityEngine;

namespace ProjectYamanote.UI
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