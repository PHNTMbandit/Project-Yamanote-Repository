using ProjectYamanote.Station.States.SuperStates;

namespace ProjectYamanote.Station.States.SubStates
{
    public class StationArrivedState : StationTrainState
    {
        public StationArrivedState(Station station, StationStateMachine stateMachine, StationData stationData, string animBoolName) : base(station, stateMachine, stationData, animBoolName)
        {
        }

        public override void DoChecks()
        {
            base.DoChecks();
        }

        public override void Enter()
        {
            base.Enter();

            station.TrainArrivedSFX();
        }

        public override void Exit()
        {
            base.Exit();
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();

            if(station.isArrived == true)
                stateMachine.ChangeState(station.IdleState);
        }

        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();
        }
    }
}