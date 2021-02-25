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

            station.StartCoroutine(station.trainAnnouncement.ShowTrainAnnouncementAlert
                ("The doors are now closing. Do not try to get on the train."));

            station.isArrived = false;
            station.isDeparting = false;
            station.TrainDeparting();
            station.TrainDepartingSFX();
        }

        public override void Exit()
        {
            base.Exit();
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();

            if (station.isDeparted == true)
                stateMachine.ChangeState(station.DespawnState);
        }

        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();
        }
    }
}