using ProjectYamanote.Train.States.SuperStates;

namespace ProjectYamanote.Train.States.SubStates
{
    public class TrainArrivedState : TrainInsideState
    {
        public TrainArrivedState(Train train, TrainStateMachine stateMachine, TrainData trainData, string animBoolName) : base(train, stateMachine, trainData, animBoolName)
        {
        }

        public override void DoChecks()
        {
            base.DoChecks();
        }

        public override void Enter()
        {
            base.Enter();

            train.isArrived = true;

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