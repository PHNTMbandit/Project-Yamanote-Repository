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

        private GameObject _gameClockGO;
        private DateTime _gameClock;

        private void Awake()
        {
            _gameClockGO = GameObject.FindGameObjectWithTag("Clock");
            _gameClock = _gameClockGO.GetComponent<GameClock>().dateTime;
        }

        private void Update()
        {
            Debug.Log(_gameClock.TimeOfDay);
            _menuTime.text = _gameClock.ToString("t");
            _menuDate.text = _gameClock.ToString("dddd, dd MMM yyyy");
            _actionBarTime.text = _gameClock.ToString("t");
            _actionBarDate.text = _gameClock.ToString("dddd, dd MMM yyyy");
        }
    }
}