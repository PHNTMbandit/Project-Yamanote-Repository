namespace ProjectYamanote.Station
{
    public class StationArrivingState : StationTrainState
    {
        public StationArrivingState(StationController station, StationStateMachine stateMachine, StationData stationData, string animBoolName) : base(station, stateMachine, stationData, animBoolName)
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
                ("Train will arrive soon. Please stand behind the yellow line."));
           
            station.TrainArriving();
            station.TrainArrivingSFX();
            
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
                stateMachine.ChangeState(station.ArrivedState);
        }

        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();
        }
    }
}