using UnityEngine;
using PixelCrushers;
using UnityEngine.UI;
using TMPro;

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
        }

        public void Quit()
        {
            Application.Quit();
        }
    }
}