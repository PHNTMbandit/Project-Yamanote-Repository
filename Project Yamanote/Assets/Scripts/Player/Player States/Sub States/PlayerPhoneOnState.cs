namespace ProjectYamanote.Player
{
    public class PlayerPhoneOnState : PlayerGroundedState
    {
        public PlayerPhoneOnState(PlayerController player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
        {
        }

        public override void DoChecks()
        {
            base.DoChecks();
        }

        public override void Enter()
        {
            base.Enter();

            player.PhoneAnimator.SetBool("phoneOn", true);
            player.PhoneOnSFX();
        }

        public override void Exit()
        {
            base.Exit();
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();

            if (PhoneInput)
            {
                player.InputHandler.UsePhoneInput();
                stateMachine.ChangeState(player.PhoneOffState);
            }
        }

        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();
        }
    }
}