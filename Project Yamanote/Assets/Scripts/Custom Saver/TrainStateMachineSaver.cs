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
            if (data.animBoolName == "travelling")
                m_train.StateMachine.Intialise(m_train.TravellingState);
        }

        public override void ApplyDataImmediate()
        {
            base.ApplyDataImmediate();
        }
    }
}