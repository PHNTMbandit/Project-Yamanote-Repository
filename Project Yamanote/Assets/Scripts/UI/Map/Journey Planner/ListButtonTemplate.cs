using System;
using UnityEngine;
using TMPro;
using ProjectYamanote.ScriptableObjects;

namespace ProjectYamanote.UI.Map.JourneyPlanner
{
    public class ListButtonTemplate : MonoBehaviour
    {
        #region Variables
        [SerializeField] private GameObject _trainStations;
        [SerializeField] private TextMeshProUGUI _textCost;
        [SerializeField] private TextMeshProUGUI _textArriveTime;
        [SerializeField] private TextMeshProUGUI _textDepartTime;
        [SerializeField] private TextMeshProUGUI _textInTime;
        [SerializeField] private TextMeshProUGUI _textTakeTime;
        [SerializeField] private GameObject _gameObjectRoutes;
        [SerializeField] private GameObject _trainImage;
        [SerializeField] private GameObject _shinkansenImage;
        [SerializeField] private GameObject _divider;
        [SerializeField] private Color redColor;
        [SerializeField] private Color greenColor;
        #endregion

        #region Button Setters
        public void SetCost(int cost)
        {
            _textCost.text = cost.ToString();
            _textCost.text = string.Format("¥ {0}", cost);
        }

        public void SetArriveTime(DateTime arriveTime)
        {
            _textArriveTime.text = arriveTime.ToString("H:mm");
        }

        public void SetDepartTime(DateTime departTime)
        {
            _textDepartTime.text = departTime.ToString("H:mm");
        }

        public void SetTransferImage(Routes.TransferVariables[] numberOfTransfer)
        {
            foreach (var i in numberOfTransfer)
            {
                if (i.transferTrainLine.Contains("JP") || i.transferTrainLine.Contains("Resort"))
                {
                    GameObject trainImage = Instantiate(_trainImage, _gameObjectRoutes.transform);
                    trainImage.transform.SetParent(_gameObjectRoutes.transform, false);
                }
                if (i.transferTrainLine.Contains("Shinkansen"))
                {
                    GameObject trainImage = Instantiate(_shinkansenImage, _gameObjectRoutes.transform);
                    trainImage.transform.SetParent(_gameObjectRoutes.transform, false);
                }
            }
        }

        public void SetTakeTime(TimeSpan takeTime)
        {
            _textTakeTime.text = takeTime.TotalMinutes.ToString() + " mins";
        }

        public void SetInTime(DateTime departTime)
        {
            TimeSpan inTime = departTime.TimeOfDay - GameClock.dateTime.TimeOfDay;

            _textInTime.text = "in " + inTime.TotalMinutes.ToString() + " mins";

            if (inTime.Minutes <= 0)
            {
                _textInTime.text = "Missed";
                _textInTime.color = redColor;
            }
            else
            {
                _textInTime.color = greenColor;
            }
        }

        public void SetFirstImage(string trainLine)
        {
            if (trainLine.Contains("JP"))
            {
                GameObject trainImage = Instantiate(_trainImage, _gameObjectRoutes.transform);
                trainImage.transform.SetParent(_gameObjectRoutes.transform, false);
            }
            else if (trainLine.Contains("Shinkansen"))
            {
                GameObject trainImage = Instantiate(_shinkansenImage, _gameObjectRoutes.transform);
                trainImage.transform.SetParent(_gameObjectRoutes.transform, false);
            }
        }

        public void SetMapTrainRoute(int originStation, int destinationStation, int transferStation)
        {

        }
        #endregion

        public void OnClick()
        {         
        }
    }
}
