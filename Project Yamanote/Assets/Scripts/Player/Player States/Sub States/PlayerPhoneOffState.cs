using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPhoneOffState : PlayerGroundedState
{
    public PlayerPhoneOffState(PlayerController playerController, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) : base(playerController, stateMachine, playerData, animBoolName)
    {
    }

    public override void DoChecks()
    {
        base.DoChecks();
    }

    public override void Enter()
    {
        base.Enter();

        playerController.PhoneAnimator.SetBool("phoneOn", false);
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if(isAnimationFinished && playerController.isSeated == false)
        {
            stateMachine.ChangeState(playerController.IdleState);
            playerController.PhoneAnimator.SetBool("phoneOn", false);
        }
        else if(isAnimationFinished && playerController.isSeated == true)
        {
            stateMachine.ChangeState(playerController.SitDownState);
            playerController.PhoneAnimator.SetBool("phoneOn", false);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
