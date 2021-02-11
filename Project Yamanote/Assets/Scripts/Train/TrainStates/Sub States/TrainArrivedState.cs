using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        train.StartCoroutine(train.TrainArrivedCouroutine());
        train.trainStation.transform.position = train.arrivedTransfrom.position;
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if (train.isDeparted == true)
            stateMachine.ChangeState(train.DepartingState);
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
