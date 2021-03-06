using UnityEngine;

namespace ProjectYamanote.Station
{
    public class StationState
    {
        protected StationController station;
        protected StationStateMachine stateMachine;
        protected StationData stationData;

        protected bool isAnimationFinished;

        protected float startTime;

        public string animBoolName;

        public StationState(StationController station, StationStateMachine stateMachine, StationData stationData, string animBoolName)
        {
            this.station = station;
            this.stateMachine = stateMachine;
            this.stationData = stationData;
            this.animBoolName = animBoolName;
        }

        public virtual void Enter()
        {
            DoChecks();
            station.Animator.SetBool(animBoolName, true);

            startTime = UnityEngine.Time.time;
            Debug.Log(animBoolName);
            isAnimationFinished = false;
        }

        public virtual void Exit()
        {
            station.Animator.SetBool(animBoolName, false);
        }

        public virtual void LogicUpdate()
        {
        }

        public virtual void PhysicsUpdate()
        {
            DoChecks();
        }

        public virtual void DoChecks()
        {
        }

        public virtual void AnimationTrigger()
        {
        }

        public virtual void AnimationFinishTrigger() => isAnimationFinished = true;
    }
}