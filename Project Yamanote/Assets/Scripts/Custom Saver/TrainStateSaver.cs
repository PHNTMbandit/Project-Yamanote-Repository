using ProjectYamanote.Train;
using System;

namespace PixelCrushers
{
    public class TrainStateSaver : Saver
    {
        [Serializable]
        public class TrainData
        {
            public string animBoolName;
            public bool isArrived;
            public bool isDeparted;
        }

        private TrainData m_data = new TrainData();
        protected TrainController m_train;

        public override void Awake()
        {
            m_train = GetComponent<TrainController>();
        }

        public override string RecordData()
        {
            m_data.animBoolName = m_train.StateMachine.CurrentState.animBoolName;
            m_data.isArrived = m_train.isArrived;
            m_data.isDeparted = m_train.isDeparted;
            return SaveSystem.Serialize(m_data);
        }

        public override void ApplyData(string s)
        {
            var data = SaveSystem.Deserialize(s, m_data);
            if (data.animBoolName == null) return;
            m_data = data;
            m_train.isArrived = data.isArrived;
            m_train.isDeparted = data.isDeparted;
            switch (data.animBoolName)
            {
                case "travelling":
                    m_train.StateMachine.ChangeState(m_train.TravellingState);
                    break;

                case "arriving":
                    m_train.StateMachine.ChangeState(m_train.ArrivingState);
                    break;

                case "arrived":
                    m_train.StateMachine.ChangeState(m_train.ArrivedState);
                    break;

                case "idle":
                    m_train.StateMachine.ChangeState(m_train.IdleState);
                    break;

                case "departing":
                    m_train.StateMachine.ChangeState(m_train.DepartingState);
                    break;
            }
        }

        public override void ApplyDataImmediate()
        {
            base.ApplyDataImmediate();
        }
    }
}