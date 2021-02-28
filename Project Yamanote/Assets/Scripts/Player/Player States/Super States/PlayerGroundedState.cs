namespace ProjectYamanote.Player
{
    public class PlayerGroundedState : PlayerState
    {
        protected int xInput;
        protected bool ActionInput;
        protected bool PhoneInput;
        private string playerCollision;

        public PlayerGroundedState(PlayerController player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
        {
        }

        public override void DoChecks()
        {
            base.DoChecks();

            playerCollision = player.PlayerCollision;
        }

        public override void Enter()
        {
            base.Enter();
        }

        public override void Exit()
        {
            base.Exit();
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();

            xInput = player.InputHandler.NormInputX;
            ActionInput = player.InputHandler.ActionInput;
            PhoneInput = player.InputHandler.PhoneInput;

            if (player.IsColliding == true)
            {
                switch (ActionInput, playerCollision, player.isSeated)
                {
                    case (true, "Seat", false):
                        player.InputHandler.UseActionInput();
                        stateMachine.ChangeState(player.SitDownState);
                        break;

                    default:
                        player.InputHandler.UseActionInput();
                        break;
                }
            }

            if (PhoneInput)
            {
                player.InputHandler.UsePhoneInput();
                stateMachine.ChangeState(player.PhoneOnState);
                player.menu.SetActive(true);
            }
        }

        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();
        }
    }
}