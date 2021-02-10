using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPhoneOnState : PlayerGroundedState
{
    public PlayerPhoneOnState(PlayerController playerController, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) : base(playerController, stateMachine, playerData, animBoolName)
    {
    }

    public override void DoChecks()
    {
        base.DoChecks();
    }

    public override void Enter()
    {
        base.Enter();

        playerController.PhoneAnimator.SetBool("phoneOn", true);
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if(PhoneInput)
        {
            playerController.InputHandler.UsePhoneInput();
            stateMachine.ChangeState(playerController.PhoneOffState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
