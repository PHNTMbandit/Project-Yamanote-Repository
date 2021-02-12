using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StationArrivingState : StationTrainState
{
    public StationArrivingState(Station station, StationStateMachine stateMachine, StationData stationData, string animBoolName) : base(station, stateMachine, stationData, animBoolName)
    {
    }

    public override void DoChecks()
    {
        base.DoChecks();
    }

    public override void Enter()
    {
        base.Enter();
        station.isDeparting = false;
        station.TrainArriving();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if (station.isArrived == true)
            stateMachine.ChangeState(station.ArrivedState);
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
