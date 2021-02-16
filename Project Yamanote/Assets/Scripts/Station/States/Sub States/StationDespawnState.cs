using ProjectYamanote.Station.States.SuperStates;

namespace ProjectYamanote.Station.States.SubStates
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

            station.TrainReset();
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
                if (station.gameClock.dateTime.TimeOfDay.Equals(i.timeArriveOriginDT.TimeOfDay))
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

