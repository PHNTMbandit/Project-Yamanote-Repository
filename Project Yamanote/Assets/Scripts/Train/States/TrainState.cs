using UnityEngine;

namespace ProjectYamanote.Train
{
    public class TrainState
    {
        protected TrainController train;
        protected TrainStateMachine stateMachine;
        protected TrainData trainData;

        protected bool isAnimationFinished;

        protected float startTime;

        public string animBoolName;

        public TrainState(TrainController train, TrainStateMachine stateMachine, TrainData trainData, string animBoolName)
        {
            this.train = train;
            this.stateMachine = stateMachine;
            this.trainData = trainData;
            this.animBoolName = animBoolName;
        }

        public virtual void Enter()
        {
            DoChecks();
            startTime = UnityEngine.Time.time;
            train.Animator.SetBool(animBoolName, true);
            Debug.Log(animBoolName);
            isAnimationFinished = false;
        }

        public virtual void Exit()
        {
            train.Animator.SetBool(animBoolName, false);
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