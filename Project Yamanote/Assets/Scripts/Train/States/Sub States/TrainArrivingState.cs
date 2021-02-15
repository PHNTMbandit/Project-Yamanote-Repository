using ProjectYamanote.Train.States.SuperStates;

namespace ProjectYamanote.Train.States.SubStates
{
    public class TrainArrivingState : TrainInsideState
    {
        public TrainArrivingState(Train train, TrainStateMachine stateMachine, TrainData trainData, string animBoolName) : base(train, stateMachine, trainData, animBoolName)
        {
        }

        public override void DoChecks()
        {
            base.DoChecks();
        }

        public override void Enter()
        {
            base.Enter();

            train.SpeedDown();

            train.TrainArrivingSFX();
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