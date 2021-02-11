using Routes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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