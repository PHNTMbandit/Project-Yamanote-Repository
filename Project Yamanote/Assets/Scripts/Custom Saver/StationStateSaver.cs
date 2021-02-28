using ProjectYamanote.Station;
using System;
using UnityEngine;

namespace PixelCrushers
{
    public class StationStateSaver : Saver
    {
        [Serializable]
        public class StationData
        {
            public string animBoolName;
        }

        private StationData m_data = new StationData();
        protected StationController m_station;

        public override void Awake()
        {
            m_station = GetComponent<StationController>();
        }

        public override string RecordData()
        {
            m_data.animBoolName = m_station.StateMachine.CurrentState.animBoolName;
            return SaveSystem.Serialize(m_data);
        }

        public override void ApplyData(string s)
        {
            var data = SaveSystem.Deserialize(s, m_data);
            if (data.animBoolName == null) return;
            m_data = data;
            switch (data.animBoolName)
            {
                case "arrived":
                    m_station.StateMachine.ChangeState(m_station.ArrivedState);
                    break;
                case "arriving":
                    m_station.StateMachine.ChangeState(m_station.ArrivingState);
                    break;
                case "departing":
                    m_station.StateMachine.ChangeState(m_station.DepartingState);
                    break;
                case "despawn":
                    m_station.StateMachine.ChangeState(m_station.DespawnState);
                    break;
                case "idle":
                    m_station.StateMachine.ChangeState(m_station.IdleState);
                    break;
            }
        }
        public override void ApplyDataImmediate()
        {
            base.ApplyDataImmediate();
        }
    }
}