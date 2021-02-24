namespace ProjectYamanote.Station
{
    public class StationDepartingState : StationTrainState
    {
        public StationDepartingState(Station station, StationStateMachine stateMachine, StationData stationData, string animBoolName) : base(station, stateMachine, stationData, animBoolName)
        {
        }

        public override void DoChecks()
        {
            base.DoChecks();
        }

        public override void Enter()
        {
            base.Enter();

            station.StartCoroutine(station.TrainDepartingCouroutine());
            station.TrainDepartingSFX();
        }

        public override void Exit()
        {
            base.Exit();
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();

            if (station.isDeparting == false)
                stateMachine.ChangeState(station.DespawnState);
        }

        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();
        }
    }
}