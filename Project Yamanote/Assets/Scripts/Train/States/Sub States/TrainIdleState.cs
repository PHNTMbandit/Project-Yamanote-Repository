using UnityEngine;

namespace ProjectYamanote.Train
{
    public class TrainIdleState : TrainInsideState
    {
        public TrainIdleState(ProjectYamanote.Train.Train train, TrainStateMachine stateMachine, TrainData trainData, string animBoolName) : base(train, stateMachine, trainData, animBoolName)
        {
        }

        public override void DoChecks()
        {
            base.DoChecks();
        }

        public override void Enter()
        {
            base.Enter();

            train.StartCoroutine(train.TrainArrivedCouroutine());
            train._stationForeground.transform.position = new Vector3(10.38f, -7.706331f, 0f);
            train._stationBackground.transform.position = new Vector3(10.38f, -7.325131f, 0f);
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

        public void LoadState(TrainState savedState)
        {
            stateMachine.ChangeState(savedState);
        }
    }
}