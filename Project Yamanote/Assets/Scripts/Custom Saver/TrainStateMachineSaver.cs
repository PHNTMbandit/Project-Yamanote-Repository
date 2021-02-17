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
        
        private TrainStateMachine m_train;

        public override void Awake()
        {
            m_train = GetComponent<Train>().StateMachine;
        }

        public override string RecordData()
        {
            var currentState = m_train.CurrentState;
            m_data.trainState = currentState;
            Debug.Log(m_data.trainState);
            return SaveSystem.Serialize(m_data);
        }

        public override void ApplyData(string s)
        {
            if (string.IsNullOrEmpty(s)) return;
            var data = SaveSystem.Deserialize<TrainData>(s, m_data);
            if (data == null) return;
            m_data = data;
            Debug.Log(m_data.trainState);
            m_train.Intialise(data.trainState);
        }

        public override void ApplyDataImmediate()
        {
            base.ApplyDataImmediate();
        }

        public override void OnRestartGame()
        {
            base.OnRestartGame();
        }
    }
}