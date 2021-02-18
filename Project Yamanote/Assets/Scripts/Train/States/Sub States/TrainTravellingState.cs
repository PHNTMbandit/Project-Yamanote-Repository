using ProjectYamanote.Train.States.SuperStates;
using ProjectYamanote.Train;
using ProjectYamanote.UI;
using System;

namespace ProjectYamanote.Train.States.SubStates
{
    public class TrainTravellingState : TrainInsideState
    {
        protected DateTime dateTime;

        public TrainTravellingState(Train train, TrainStateMachine stateMachine, TrainData trainData, string animBoolName) : base(train, stateMachine, trainData, animBoolName)
        {
        }

        public override void DoChecks()
        {
            base.DoChecks();
        }

        public override void Enter()
        {
            base.Enter();

            train.TrainTravellingSFX();
        }

        public override void Exit()
        {
            base.Exit();
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();

            if (train.GameClock.TimeOfDay.Equals(TrainData.timeArriveDestinationDT.TimeOfDay))
            {
                stateMachine.ChangeState(train.ArrivingState);
            }
        }

        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();
        }
    }
}