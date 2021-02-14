using PixelCrushers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerButtons : MonoBehaviour
{
    public void Quit()
    {
        SaveSystem.LoadScene("MainMenu");
        SaveSystem.SaveToSlot(0);
    }
}
