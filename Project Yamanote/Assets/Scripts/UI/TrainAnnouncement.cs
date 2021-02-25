using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace ProjectYamanote.UI
{
    public class TrainAnnouncement : MonoBehaviour
    {
        private TextMeshProUGUI text;

        private void Start()
        {
            text = GetComponent<TextMeshProUGUI>();
            text.alpha = 0f;
        }

        public IEnumerator ShowTrainAnnouncementAlert(string message)
        {
            text.text = message;
            text.DOFade(1, 1);

            yield return new WaitForSeconds(8);

            text.DOFade(0, 1);
        }
    }
}