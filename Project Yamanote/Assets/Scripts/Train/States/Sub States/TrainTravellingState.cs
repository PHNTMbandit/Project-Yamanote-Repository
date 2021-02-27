using ProjectYamanote.UI;
using UnityEngine;

namespace ProjectYamanote.Train
{
    public class TrainTravellingState : TrainInsideState
    {
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

            train._stationForeground.transform.position = new Vector3(69.7f, -7.706331f, 0f);
            train._stationBackground.transform.position = new Vector3(69.7f, -7.325131f, 0f);
            train.TrainTravellingSFX();
        }

        public override void Exit()
        {
            base.Exit();
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();

            if (GameClock.dateTime.TimeOfDay.Equals(TrainData.timeArriveDestinationDT.TimeOfDay))
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