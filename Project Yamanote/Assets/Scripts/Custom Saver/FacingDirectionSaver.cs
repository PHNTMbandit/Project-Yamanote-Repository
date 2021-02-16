using ProjectYamanote.Player;
using System;
using UnityEngine;

namespace PixelCrushers
{
    public class FacingDirectionSaver : Saver
    {
        [Serializable]
        public class Data
        {
            public int FacingDirection;
        }

        private Data m_data = new Data();

        public override string RecordData()
        {
            m_data.FacingDirection = GetComponent<Player>().FacingDirection;
            return SaveSystem.Serialize(m_data);
        }

        public override void ApplyData(string s)
        {
            var data = SaveSystem.Deserialize<Data>(s, m_data);
            if (data == null) return;
            m_data = data;
            GetComponent<Player>().FacingDirection = m_data.FacingDirection;
        }
    }
}
