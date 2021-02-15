
using ProjectYamanote.Station.States.SuperStates;

namespace ProjectYamanote.Station.States.SubStates
{
    public class StationArrivingState : StationTrainState
    {
        public StationArrivingState(Station station, StationStateMachine stateMachine, StationData stationData, string animBoolName) : base(station, stateMachine, stationData, animBoolName)
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
            station.TrainArriving();
            station.TrainArrivingSFX();
        }

        public override void Exit()
        {
            base.Exit();
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();

            if (station.isArrived == true)
                stateMachine.ChangeState(station.ArrivedState);
        }

        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();
        }
    }
}

