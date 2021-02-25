using System;
using System.Collections.Generic;
using UnityEngine;

namespace ProjectYamanote.Station
{

    public class ResetStation : MonoBehaviour
    {
        [SerializeField] private Station station;

        public void ResetTrain()
        {
            station.StateMachine.ChangeState(station.DespawnState);
        }
    }
}
