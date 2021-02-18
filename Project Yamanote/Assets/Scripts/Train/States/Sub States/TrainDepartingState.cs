using ProjectYamanote.Train.States.SuperStates;
using UnityEngine;

namespace ProjectYamanote.Train.States.SubStates
{
    public class TrainDepartingState : TrainInsideState
    {
        public TrainDepartingState(Train train, TrainStateMachine stateMachine, TrainData trainData, string animBoolName) : base(train, stateMachine, trainData, animBoolName)
        {
        }

        public override void DoChecks()
        {
            base.DoChecks();
        }

        public override void Enter()
        {
            base.Enter();

            train.TrainDepartingSFX();
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
                train.SpeedUp();
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

