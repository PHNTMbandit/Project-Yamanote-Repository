using System;
using System.Collections;
using UnityEngine;

namespace ProjectYamanote.Persistence
{
    public class FastForward : MonoBehaviour
    {
        public bool fastForwardClock;

        public void Update()
        {
            if (fastForwardClock == true)
                StartCoroutine(FastForwardClock());
            else
                StopCoroutine(FastForwardClock());
        }

        public IEnumerator FastForwardClock()
        {
            while (fastForwardClock == true)
            {
                GameClock.dateTime = GameClock.dateTime.AddSeconds(1);

                yield return null;
            }
        }
    }
}
