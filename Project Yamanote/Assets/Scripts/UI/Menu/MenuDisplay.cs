using UnityEngine;
using TMPro;
using ProjectYamanote.Player;
using ProjectYamanote.ScriptableObjects;

namespace ProjectYamanote.UI.Menu
{
    public class MenuDisplay : MonoBehaviour
    {
        [SerializeField] private GameTime _gameTime;
        [SerializeField] private PlayerData _playerData;
        [SerializeField] private TextMeshProUGUI _menuTime;
        [SerializeField] private TextMeshProUGUI _menuDate;
        [SerializeField] private EnergyBar _energyBar;
        [SerializeField] private HungerBar _hungerBar;
        [SerializeField] private TextMeshProUGUI _actionBarTime;
        [SerializeField] private TextMeshProUGUI _actionBarDate;

        private void Update()
        {
            _menuTime.text = _gameTime.dateTime.ToString("t");
            _actionBarTime.text = _gameTime.dateTime.ToString("t");
            _menuDate.text = _gameTime.dateTime.ToString("dddd, dd MMM yyyy");
            _actionBarDate.text = _gameTime.dateTime.ToString("dddd, dd MMM yyyy");
        }

        private void UpdateStats()
        {
            _energyBar.RemoveEnergy(_playerData.energyBarSpendRate);
            _hungerBar.RemoveHunger(_playerData.hungerBarSpendRate);
        }
    }
}