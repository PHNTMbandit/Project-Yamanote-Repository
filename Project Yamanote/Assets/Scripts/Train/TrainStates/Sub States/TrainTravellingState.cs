using Routes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
