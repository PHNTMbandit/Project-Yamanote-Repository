using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGroundedState : PlayerState
{
    protected int xInput;
    protected bool ActionInput;
    protected bool PhoneInput;
    private string playerCollision;

    public PlayerGroundedState(PlayerController playerController, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) : base(playerController, stateMachine, playerData, animBoolName)
    {
    }

    public override void DoChecks()
    {
        base.DoChecks();

        playerCollision = playerController.PlayerCollision;
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

        xInput = playerController.InputHandler.NormInputX;
        ActionInput = playerController.InputHandler.ActionInput;
        PhoneInput = playerController.InputHandler.PhoneInput;

        if(playerController.IsColliding == true)
        {
            switch(ActionInput, playerCollision, playerController.isSeated)
            {
                case (true, "Seat", false):
                    playerController.InputHandler.UseActionInput();
                    stateMachine.ChangeState(playerController.SitDownState);
                    break;

                default:
                    playerController.InputHandler.UseActionInput();
                    break;
            }
        }

        if(PhoneInput) 
        {
            playerController.InputHandler.UsePhoneInput();
            stateMachine.ChangeState(playerController.PhoneOnState);
            playerController.phone.SetActive(true);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
