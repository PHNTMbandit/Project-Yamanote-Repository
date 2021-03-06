namespace ProjectYamanote.Train
{
    public class TrainArrivingState : TrainInsideState
    {
        public TrainArrivingState(TrainController train, TrainStateMachine stateMachine, TrainData trainData, string animBoolName) : base(train, stateMachine, trainData, animBoolName)
        {
        }

        public override void DoChecks()
        {
            base.DoChecks();
        }

        public override void Enter()
        {
            base.Enter();

            train.StartCoroutine(train.trainAnnouncement.ShowTrainAnnouncementAlert
                ("The next station is " + TrainData.destinationStation.ToString() + ". The doors on the left side will open."));

            train.SpeedDown();
            train.TrainArrivingSFX();

            train.saveButton.interactable = false;
        }

        public override void Exit()
        {
            base.Exit();
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();

            if (train.isArrived == true)
                stateMachine.ChangeState(train.ArrivedState);
        }

        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();
        }
    }
}