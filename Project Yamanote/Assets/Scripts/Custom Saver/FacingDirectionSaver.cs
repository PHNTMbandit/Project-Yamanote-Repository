using ProjectYamanote.Player;
using System;

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
        protected Player player;

        public override void Awake()
        {
            player = GetComponent<Player>();
        }

        public override string RecordData()
        {
            m_data.FacingDirection = player.FacingDirection;
            return SaveSystem.Serialize(m_data);
        }

        public override void ApplyData(string s)
        {
            var data = SaveSystem.Deserialize<Data>(s, m_data);
            if (data == null) return;
            m_data = data;
            player.FacingDirection = data.FacingDirection;
        }

        public override void ApplyDataImmediate()
        {
            base.ApplyDataImmediate();
        }

        public override void OnBeforeSceneChange()
        {
            base.OnBeforeSceneChange();
        }
    }
}