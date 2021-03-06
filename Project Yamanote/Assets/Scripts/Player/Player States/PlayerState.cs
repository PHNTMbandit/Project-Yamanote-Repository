using UnityEngine;

namespace ProjectYamanote.Player
{
    public class PlayerState
    {
        protected PlayerController player;
        protected PlayerStateMachine stateMachine;
        protected PlayerData playerData;

        protected bool isAnimationFinished;

        protected float startTime;

        private string animBoolName;

        public PlayerState(PlayerController player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName)
        {
            this.player = player;
            this.stateMachine = stateMachine;
            this.playerData = playerData;
            this.animBoolName = animBoolName;
        }

        public virtual void Enter()
        {
            DoChecks();
            player.PlayerAnimator.SetBool(animBoolName, true);
            startTime = UnityEngine.Time.time;
            Debug.Log(animBoolName);
            isAnimationFinished = false;
        }

        public virtual void Exit()
        {
            player.PlayerAnimator.SetBool(animBoolName, false);
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