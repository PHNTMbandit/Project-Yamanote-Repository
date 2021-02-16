using UnityEngine;
using TMPro;
using ProjectYamanote.Player;
using System.Collections;
using System;

namespace ProjectYamanote.UI.Menu
{
    public class MenuDisplay : MonoBehaviour
    {
        [SerializeField] private PlayerData _playerData;
        [SerializeField] private TextMeshProUGUI _menuTime;
        [SerializeField] private TextMeshProUGUI _menuDate;
        [SerializeField] private EnergyBar _energyBar;
        [SerializeField] private HungerBar _hungerBar;
        [SerializeField] private TextMeshProUGUI _actionBarTime;
        [SerializeField] private TextMeshProUGUI _actionBarDate;

        private void Update()
        {
            GameClock.dateTime.AddSeconds(1);
            _menuTime.text = GameClock.dateTime.ToString("t");
            _actionBarTime.text = GameClock.dateTime.ToString("t");
            _menuDate.text = GameClock.dateTime.ToString("dddd, dd MMM yyyy");
            _actionBarDate.text = GameClock.dateTime.ToString("dddd, dd MMM yyyy");
        }

        private void UpdateStats()
        {
            _energyBar.RemoveEnergy(_playerData.energyBarSpendRate);
            _hungerBar.RemoveHunger(_playerData.hungerBarSpendRate);
        }
    }
}