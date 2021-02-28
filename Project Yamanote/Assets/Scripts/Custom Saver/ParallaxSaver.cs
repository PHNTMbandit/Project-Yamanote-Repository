using EasyParallax;
using ProjectYamanote.Train;
using System;
using System.Collections;

namespace PixelCrushers
{
    public class ParallaxSaver : Saver
    {
        [Serializable]
        public class ParallaxData
        {
            public float speed;
            public IEnumerator speedUp;
        }

        private ParallaxData m_data = new ParallaxData();
        public TrainController train;
        protected SpriteMovement spriteMovement;

        public override void Awake()
        {
            spriteMovement = GetComponent<SpriteMovement>();
        }

        public override string RecordData()
        {
            m_data.speed = spriteMovement.speed;
            m_data.speedUp = spriteMovement.SpeedUpParallax();

            return SaveSystem.Serialize(m_data);
        }

        public override void ApplyData(string s)
        {
            var data = SaveSystem.Deserialize(s, m_data);
            if (data == null) return;
            m_data = data;
            spriteMovement.speed = data.speed;
        }

        public override void ApplyDataImmediate()
        {
            base.ApplyDataImmediate();
        }
    }
}