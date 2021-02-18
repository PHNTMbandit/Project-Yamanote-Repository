using PixelCrushers;
using UnityEngine;
using ProjectYamanote.Train;
using UnityEngine.UI;

namespace ProjectYamanote.UI.Power
{
    public class PowerButtons : MonoBehaviour
    {
        private string _train;
        private string _station;
        private Button _button;

        private bool _isOff;

        private void Awake()
        {
            _train = GetComponent<Train.Train>().StateMachine.CurrentState.animBoolName;
            _station = GetComponent<Station.Station>().StateMachine.CurrentState.animBoolName;
            _button = GetComponent<Button>();
        }

        private void Update()
        {
            if (_train == "departing")
            {
                _button.interactable = false;
                _isOff = true;
            }

            if (_train == "arriving")
            {
                _button.interactable = false;
                _isOff = true;
            }

            if (_station == "departing")
            {
                _button.interactable = false;
                _isOff = true;
            }

            if (_station == "arriving")
            {
                _button.interactable = false;
                _isOff = true;
            }

            else
            {
                _button.interactable = true;
                _isOff = true;
            }
        }

        public void Quit()
        {
            SaveSystem.LoadScene("MainMenu");
            SaveSystem.SaveToSlot(0);
        }
    }
}