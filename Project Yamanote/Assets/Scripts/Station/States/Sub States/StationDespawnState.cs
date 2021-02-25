using ProjectYamanote.UI;

namespace ProjectYamanote.Station
{
    public class StationDespawnState : StationTrainState
    {
        public StationDespawnState(Station station, StationStateMachine stateMachine, StationData stationData, string animBoolName) : base(station, stateMachine, stationData, animBoolName)
        {
        }

        public override void DoChecks()
        {
            base.DoChecks();
        }

        public override void Enter()
        {
            base.Enter();

            station.isDeparting = false;
            station.isArrived = false;
            station.train.transform.position = station.instantiatePosition.position;
            station.TrainDespawnSFX();
        }

        public override void Exit()
        {
            base.Exit();
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();

            foreach (var i in stationData.trainSchedule)
            {
                if (GameClock.dateTime == i.timeArriveOriginDT)
                {
                    stateMachine.ChangeState(station.ArrivingState);
                }
            }
        }

        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();
        }
    }
}