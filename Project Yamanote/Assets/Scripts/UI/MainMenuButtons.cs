using UnityEngine;
using PixelCrushers;
using UnityEngine.UI;
using TMPro;
using System;

namespace ProjectYamanote.UI
{
    public class MainMenuButtons : MonoBehaviour
    {
        [SerializeField] private Button _startButton;
        [SerializeField] private TextMeshProUGUI _startText;

        private DateTime gameClock;

        public void Awake()
        {
            gameClock = GetComponent<GameClock>().dateTime;

            if (!(SaveSystem.HasSavedGameInSlot(0)))
            {
                _startButton.interactable = false;
                _startText.color = new Color32(255, 255, 255, 100);
            }
        }

        public void New()
        {
            PlayerPrefs.DeleteAll();
            gameClock = new DateTime(2021, 12, 04, 17, 26, 00);
        }

        public void Quit()
        {
            Application.Quit();
        }
    }
}