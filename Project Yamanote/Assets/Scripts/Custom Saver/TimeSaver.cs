using ProjectYamanote.UI;
using System;
using UnityEngine;

namespace PixelCrushers
{
    public class TimerSaver : Saver
    {
        [Serializable]
        public class TimeData
        {
            public int year;
            public int month;
            public int day;
            public int hour;
            public int minute;
            public int second;
        }

        private TimeData m_data = new TimeData();
        protected System.DateTime m_time;

        public override void Awake()
        {
            m_time = GetComponent<ProjectYamanote.UI.GameClock>().dateTime;
        }

        public override string RecordData()
        {
            m_data.year = m_time.Year;
            m_data.month = m_time.Month;
            m_data.day = m_time.Day;
            m_data.hour = m_time.Hour;
            m_data.month = m_time.Month;
            m_data.day = m_time.Day;

            return SaveSystem.Serialize(m_data);
        }

        public override void ApplyData(string s)
        {
            var data = SaveSystem.Deserialize(s, m_data);
            if (data == null) return;
            m_data = data;
            m_time = new System.DateTime(data.year, data.month, data.day, data.hour, data.month, data.day);
        }

        public override void ApplyDataImmediate()
        {
            base.ApplyDataImmediate();
        }
    }
}