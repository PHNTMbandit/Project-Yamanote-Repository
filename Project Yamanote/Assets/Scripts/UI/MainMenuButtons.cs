using PixelCrushers;
using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace ProjectYamanote.UI
{
    public class MainMenuButtons : MonoBehaviour
    {
        [SerializeField] private Button _startButton;
        [SerializeField] private TextMeshProUGUI _startText;

        public void Awake()
        {
            if (!(SaveSystem.HasSavedGameInSlot(0)))
            {
                _startButton.interactable = false;
                _startText.color = new Color32(255, 255, 255, 100);
            }
        }

        public void New()
        {
            PlayerPrefs.DeleteAll();
            GameClock.dateTime = new DateTime(2021, 12, 04, 5, 45, 50);
        }

        public void Quit()
        {
            Application.Quit();
        }
    }
}