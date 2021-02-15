using UnityEngine;

namespace ProjectYamanote.Station.States
{
    public class StationState
    {
        protected Station station;
        protected StationStateMachine stateMachine;
        protected StationData stationData;

        protected bool isAnimationFinished;

        protected float startTime;

        private string animBoolName;

        public StationState(Station station, StationStateMachine stateMachine, StationData stationData, string animBoolName)
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

        public virtual void LogicUpdate() { }

        public virtual void PhysicsUpdate()
        {
            DoChecks();
        }

        public virtual void DoChecks() { }

        public virtual void AnimationTrigger() { }

        public virtual void AnimationFinishTrigger() => isAnimationFinished = true;
    }
}
