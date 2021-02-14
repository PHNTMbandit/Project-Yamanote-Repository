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
        if (!(SaveSystem.HasSavedGameInSlot(0)))
        {
            startButton.interactable = false;
            startText.color = new Color32(255, 255, 255, 100);
        }
    }

    public void New()
    { 
        PlayerPrefs.DeleteAll();
    }

    public void Quit()
    {
        Application.Quit();
    }
}
