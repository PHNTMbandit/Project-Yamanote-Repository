using ProjectYamanote.Train;
using ProjectYamanote.Train.States;
using System;
using UnityEngine;

namespace PixelCrushers
{
    public class TrainStateMachineSaver : Saver
    {
        [Serializable]
        public class TrainData
        {
            public TrainState trainState;
        }

        private TrainData m_data = new TrainData();
        protected Train m_train;

        public override void Awake()
        {
            m_train = GetComponent<Train>();
        }

        public override string RecordData()
        {
            m_data.trainState = m_train.StateMachine.CurrentState;
            Debug.Log(m_data.trainState);
            return SaveSystem.Serialize(m_data);
        }

        public override void ApplyData(string s)
        {
            var data = SaveSystem.Deserialize(s, m_data);
            if (data.trainState == null) return;
            m_data = data;
            Debug.Log(data.trainState);
            m_train.StateMachine.ChangeState(data.trainState);
        }
    }
}