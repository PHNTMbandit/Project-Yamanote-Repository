namespace ProjectYamanote.Station
{
    public class StationArrivedState : StationTrainState
    {
        public StationArrivedState(StationController station, StationStateMachine stateMachine, StationData stationData, string animBoolName) : base(station, stateMachine, stationData, animBoolName)
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
           
            station.waitTimeButton.interactable = false;
            station.saveButton.interactable = false;
        }

        public override void Exit()
        {
            base.Exit();
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();

            if (station.isArrived == true)
                stateMachine.ChangeState(station.IdleState);
        }

        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();
        }
    }
}