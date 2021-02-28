using ProjectYamanote.Train;
using System;

namespace PixelCrushers
{
    public class ITweenSaver : Saver
    {
        [Serializable]
        public class ItweenData
        {
        }

        private ItweenData m_data = new ItweenData();
        public TrainController train;

        public override void Awake()
        {
            train = GetComponent<TrainController>();
        }

        public override string RecordData()
        {
            return SaveSystem.Serialize(m_data);
        }

        public override void ApplyData(string s)
        {
            var data = SaveSystem.Deserialize(s, m_data);
            if (data == null) return;
            m_data = data;
        }

        public override void ApplyDataImmediate()
        {
            base.ApplyDataImmediate();
        }
    }
}