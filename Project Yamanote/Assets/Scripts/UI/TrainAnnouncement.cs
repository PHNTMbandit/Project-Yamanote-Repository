using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace ProjectYamanote.UI
{
    public class TrainAnnouncement : MonoBehaviour
    {
        private TextMeshProUGUI textTemplate;
        public GameObject test;

        private void Start()
        {
            textTemplate = GetComponent<TextMeshProUGUI>();
        }

        public void ShowTrainAnnouncement(string message)
        {
            textTemplate.text = message;
            
        }
    }
}
