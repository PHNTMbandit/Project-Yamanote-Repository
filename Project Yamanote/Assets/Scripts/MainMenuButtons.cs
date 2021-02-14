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

    public void Awake()
    {
        if (SaveSystem.HasSavedGameInSlot(0))
        {
            startButton.enabled = false;
            //startText.color.a = 0.5f;
        }
    }

    public void Quit()
    {
        Application.Quit();
    }
}
