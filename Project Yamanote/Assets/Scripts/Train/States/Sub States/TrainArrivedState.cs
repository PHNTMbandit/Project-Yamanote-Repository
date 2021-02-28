namespace ProjectYamanote.Train
{
    public class TrainArrivedState : TrainInsideState
    {
        public TrainArrivedState(TrainController train, TrainStateMachine stateMachine, TrainData trainData, string animBoolName) : base(train, stateMachine, trainData, animBoolName)
        {
        }

        public override void DoChecks()
        {
            base.DoChecks();
        }

        public override void Enter()
        {
            base.Enter();

            train.saveButton.interactable = false;
            
            train.TrainArrivedSFX();
        }

        public override void Exit()
        {
            base.Exit();
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();

            if (isAnimationFinished == true)
                stateMachine.ChangeState(train.IdleState);
        }

        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();
        }
    }
}