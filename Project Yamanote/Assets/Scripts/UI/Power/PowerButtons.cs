using PixelCrushers;
using UnityEngine;
using UnityEngine.UI;

namespace ProjectYamanote.UI
{
    public class PowerButtons : MonoBehaviour
    {
        [SerializeField] private GameObject _tooltip;
        [SerializeField] private Button _saveButton;

        private void Update()
        {
            if (_saveButton.interactable == false)
                _tooltip.SetActive(true);
            else
                _tooltip.SetActive(false);
        }

        public void Save()
        {
            SaveSystem.SaveToSlot(0);
        }

        public void Quit()
        {
            SaveSystem.LoadScene("MainMenu");
        }
    }
}