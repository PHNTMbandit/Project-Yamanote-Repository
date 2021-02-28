namespace ProjectYamanote.Train
{
    public class TrainDepartingState : TrainInsideState
    {
        public TrainDepartingState(TrainController train, TrainStateMachine stateMachine, TrainData trainData, string animBoolName) : base(train, stateMachine, trainData, animBoolName)
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
                ("The doors are now closing. This train is bound for " + TrainData.destinationStation.ToString() + "."));

            train.SpeedUp();
            train.TrainDepartingSFX();

            train.saveButton.interactable = false;
        }

        public override void Exit()
        {
            base.Exit();
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();

            if (isAnimationFinished)
            {
                train.isArrived = false;
            }

            if (train.isDeparted == false)
                stateMachine.ChangeState(train.TravellingState);
        }

        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();
        }
    }
}