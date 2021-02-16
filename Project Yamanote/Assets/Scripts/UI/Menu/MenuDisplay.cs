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
        [SerializeField] private TextMeshProUGUI _actionBarTime;
        [SerializeField] private TextMeshProUGUI _actionBarDate;

        private void Update()
        {
            _menuTime.text = GameClock.dateTime.ToString("t");
            _menuDate.text = GameClock.dateTime.ToString("dddd, dd MMM yyyy");
            _actionBarTime.text = GameClock.dateTime.ToString("t");
            _actionBarDate.text = GameClock.dateTime.ToString("dddd, dd MMM yyyy");
        }
    }
}