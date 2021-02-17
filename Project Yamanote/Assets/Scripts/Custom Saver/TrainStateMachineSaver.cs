using ProjectYamanote.Station;
using ProjectYamanote.Station.States;
using System;
using UnityEngine;

namespace PixelCrushers
{
    public class TrainStateMachineSaver : Saver
    {
        [Serializable]
        public class Data
        {
            public StationState currentState;
        }

        private Data m_data = new Data();

        public override string RecordData()
        {

            return SaveSystem.Serialize(m_data);
        }

        public override void ApplyData(string s)
        {
            var data = SaveSystem.Deserialize<Data>(s, m_data);
            if (data == null) return;
            m_data = data;
        }
    }
}