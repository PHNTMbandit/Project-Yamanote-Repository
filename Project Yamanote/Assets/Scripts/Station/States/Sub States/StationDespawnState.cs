using ProjectYamanote.UI;
using UnityEngine;

namespace ProjectYamanote.Station
{
    public class StationDespawnState : StationTrainState
    {
        public StationDespawnState(StationController station, StationStateMachine stateMachine, StationData stationData, string animBoolName) : base(station, stateMachine, stationData, animBoolName)
        {
        }

        public override void DoChecks()
        {
            base.DoChecks();
        }

        public override void Enter()
        {
            base.Enter();

            station.train.transform.position = new Vector3(47.1f, -0.03298116f, 0f);

            station.isDeparted = false;

            station.TrainDespawnSFX();

            station.waitTimeButton.interactable = true;
            station.saveButton.interactable = true;
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
                if (GameClock.dateTime.TimeOfDay == i.timeArriveOriginDT.TimeOfDay)
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
}