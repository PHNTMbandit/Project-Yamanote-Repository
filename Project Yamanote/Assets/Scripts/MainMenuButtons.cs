using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PixelCrushers;
using UnityEngine.UI;
using TMPro;

public class MainMenuButtons : MonoBehaviour
{
    [SerializeField] private Button startButton;
    [SerializeField] private TextMeshProUGUI startText;

    private void Start()
    {
        if (SaveSystem.HasSavedGameInSlot(0))
        {
            print("has game in slot");
        }
    }

    public void Play()
    {
        SaveSystem.LoadFromSlot(0);
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void New()
    {
        SaveSystem.ClearSavedGameData();
        SaveSystem.DeleteSavedGameInSlot(0);
        SaveSystem.LoadScene("Tsugaru Line");
    }
}
