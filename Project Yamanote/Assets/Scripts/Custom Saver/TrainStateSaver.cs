using ProjectYamanote.Train;
using ProjectYamanote.Train.States;
using System;
using UnityEngine;

namespace PixelCrushers
{
    public class TrainStateSaver : Saver
    {
        [Serializable]
        public class TrainData
        {
            public string animBoolName;
        }

        private TrainData m_data = new TrainData();
        protected Train m_train;

        public override void Awake()
        {
            m_train = GetComponent<Train>();
        }

        public override string RecordData()
        {
            m_data.animBoolName = m_train.StateMachine.CurrentState.animBoolName;
            return SaveSystem.Serialize(m_data);
        }

        public override void ApplyData(string s)
        {
            var data = SaveSystem.Deserialize(s, m_data);
            if (data.animBoolName == null) return;
            m_data = data;
            switch (data.animBoolName)
            {
                case "travelling":
                    m_train.StateMachine.ChangeState(m_train.TravellingState);
                    break;
                case "arriving":
                    m_train.StateMachine.ChangeState(m_train.ArrivingState);
                    break;
                case "arrived":
                    m_train.StateMachine.ChangeState(m_train.ArrivedState);
                    break;
                case "idle":
                    m_train.StateMachine.ChangeState(m_train.IdleState);
                    break;
                case "departing":
                    m_train.StateMachine.ChangeState(m_train.DepartingState);
                    break;
            }
        }

        public override void ApplyDataImmediate()
        {
            base.ApplyDataImmediate();
        }
    }
}