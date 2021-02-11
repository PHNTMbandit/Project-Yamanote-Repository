using Routes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
            stateMachine.ChangeState(train.TravellingState);
            Debug.Log("animation finished");
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
