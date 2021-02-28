namespace ProjectYamanote.Player
{
    public class PlayerSitDownState : PlayerGroundedState
    {
        public PlayerSitDownState(PlayerController player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
        {
        }

        public override void DoChecks()
        {
            base.DoChecks();
        }

        public override void Enter()
        {
            base.Enter();

            player.isSeated = true;
            player.actionText.enabled = false;
            player.playerCollider.enabled = false;
        }

        public override void Exit()
        {
            base.Exit();
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();

            if (player.isSeated == true && ActionInput)
            {
                player.isSeated = false;
                player.InputHandler.UseActionInput();
                stateMachine.ChangeState(player.SitUpState);
            }
        }

        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();
        }
    }
}