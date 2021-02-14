using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StationDespawnState : StationTrainState
{
    public StationDespawnState(Station station, StationStateMachine stateMachine, StationData stationData, string animBoolName) : base(station, stateMachine, stationData, animBoolName)
    {
    }

    public override void DoChecks()
    {
        base.DoChecks();
    }

    public override void Enter()
    {
        base.Enter();

        station.TrainReset();
        station.TrainDespawnSFX();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        foreach (var i in stationData.trainSchedule)
        {
            if (GameClock.dateTime.TimeOfDay.Equals(i.timeArriveOriginDT.TimeOfDay))
            {
                stateMachine.ChangeState(station.ArrivingState);
            }
        }
    }
    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
