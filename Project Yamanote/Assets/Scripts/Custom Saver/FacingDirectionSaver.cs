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
            public Transform transform;
            public bool IsFlipped;
        }

        private Data m_data = new Data();
        protected PlayerController player;

        public override void Awake()
        {
            player = GetComponent<PlayerController>();
        }

        public override string RecordData()
        {
            m_data.FacingDirection = player.FacingDirection;
            m_data.transform = player.transform;
            m_data.IsFlipped = player.IsFlipped;
            return SaveSystem.Serialize(m_data);
        }

        public override void ApplyData(string s)
        {
            if (string.IsNullOrEmpty(s)) return;
            var data = SaveSystem.Deserialize<Data>(s, m_data);
            if (data == null) return;
            m_data = data;
            player.FacingDirection = data.FacingDirection;
            if (data.IsFlipped == true)
            {
                player.transform.eulerAngles = new Vector3(0.0f, 180.0f, 0.0f);
            }
        }

        public override void ApplyDataImmediate()
        {
            base.ApplyDataImmediate();
        }
    }
}