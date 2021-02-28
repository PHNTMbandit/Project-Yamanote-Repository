using DG.Tweening;
using ProjectYamanote.UI;
using UnityEngine;
using UnityEngine.UI;

namespace ProjectYamanote.Train
{
    public class TrainTravellingState : TrainInsideState
    {
        public TrainTravellingState(TrainController train, TrainStateMachine stateMachine, TrainData trainData, string animBoolName) : base(train, stateMachine, trainData, animBoolName)
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

            train.saveButton.interactable = true;
            train.skipButton.SetActive(true);
            train.skipButton.GetComponent<Button>().image.DOFade(1, 1);
        }

        public override void Exit()
        {
            base.Exit();

            train.skipButton.SetActive(false);
            train.skipButton.GetComponent<Button>().image.DOFade(0, 1);
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