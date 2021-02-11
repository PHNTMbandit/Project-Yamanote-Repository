using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StationArrivedState : StationTrainState
{
    public StationArrivedState(Station station, StationStateMachine stateMachine, StationData stationData, string animBoolName) : base(station, stateMachine, stationData, animBoolName)
    {
    }

    public override void DoChecks()
    {
        base.DoChecks();
    }

    public override void Enter()
    {
        base.Enter();

        station.StartCoroutine(station.TrainArrivedCouroutine());
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if (station.isDeparting == true)
            stateMachine.ChangeState(station.DepartingState);
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}