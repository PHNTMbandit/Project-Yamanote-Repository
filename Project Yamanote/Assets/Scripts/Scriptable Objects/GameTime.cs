using System;
using System.Collections;
using UnityEngine;

namespace ProjectYamanote.ScriptableObjects
{
    [CreateAssetMenu(fileName = "GameTime", menuName = "Scriptable Objects")]
    public class GameTime : ScriptableObject
    {
        public DateTime dateTime = new DateTime(2021, 12, 04, 17, 29, 00);

        public IEnumerator SecondTimer()
        {
            while (dateTime.Second <= 60)
            {
                dateTime = dateTime.AddSeconds(1);

                yield return new WaitForSeconds(1);
            }
        }
    }

    public class Timer : MonoBehaviour
    {
        public GameTime time;

        private void Start()
        {
            StartCoroutine(time.SecondTimer());
        }
    }
}