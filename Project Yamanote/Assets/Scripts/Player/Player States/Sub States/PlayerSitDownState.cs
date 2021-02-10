using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSitDownState : PlayerGroundedState
{
    public PlayerSitDownState(PlayerController playerController, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) : base(playerController, stateMachine, playerData, animBoolName)
    {
    }

    public override void DoChecks()
    {
        base.DoChecks();
    }

    public override void Enter()
    {
        base.Enter();

        playerController.isSeated = true;
        playerController.actionText.enabled = false;
        playerController.playerCollider.enabled = false;
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if(playerController.isSeated == true && ActionInput)
        {
            playerController.isSeated = false;
            playerController.InputHandler.UseActionInput();
            stateMachine.ChangeState(playerController.SitUpState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
