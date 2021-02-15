using ProjectYamanote.Player.PlayerStates.SuperStates;

namespace ProjectYamanote.Player.PlayerStates.SubStates
{
    public class PlayerPhoneOffState : PlayerGroundedState
    {
        public PlayerPhoneOffState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
        {
        }

        public override void DoChecks()
        {
            base.DoChecks();
        }

        public override void Enter()
        {
            base.Enter();

            player.PhoneAnimator.SetBool("phoneOn", false);
            player.PhoneOffSFX();
        }

        public override void Exit()
        {
            base.Exit();
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();

            if (isAnimationFinished && player.isSeated == false)
            {
                stateMachine.ChangeState(player.IdleState);
                player.PhoneAnimator.SetBool("phoneOn", false);
            }
            else if (isAnimationFinished && player.isSeated == true)
            {
                stateMachine.ChangeState(player.SitDownState);
                player.PhoneAnimator.SetBool("phoneOn", false);
            }
        }

        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();
        }
    }
}
