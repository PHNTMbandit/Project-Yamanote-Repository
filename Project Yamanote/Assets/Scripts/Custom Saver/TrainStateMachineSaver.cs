using ProjectYamanote.Train;
using ProjectYamanote.Train.States;
using System;
using UnityEngine;

namespace PixelCrushers
{
    public class TrainStateMachineSaver : Saver
    {
        [Serializable]
        public class Data
        {
            public TrainStateMachine trainStateMachine;
        }

        private Data m_data = new Data();

        public override string RecordData()
        {
            m_data.trainStateMachine = GetComponent<Train>().StateMachine;
            return SaveSystem.Serialize(m_data);
        }

        public override void ApplyData(string s)
        {
            var data = SaveSystem.Deserialize<Data>(s, m_data);
            if (data == null) return;
            m_data = data;
            GetComponent<Train>().StateMachine.Intialise(m_data.trainStateMachine.CurrentState);
        }
    }
}