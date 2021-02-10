using UnityEditor;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerStateMachine
{
    public PlayerState CurrentState { get; private set; }

    public void Initialise(PlayerState startingState)
    {
        CurrentState = startingState;
        CurrentState.Enter();
    }

    public void ChangeState(PlayerState newState)
    {
        CurrentState.Exit();
        CurrentState = newState;
        CurrentState.Enter();
    }
}