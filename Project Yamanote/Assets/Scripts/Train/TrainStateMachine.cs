using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainStateMachine
{
    public TrainState CurrentState { get; private set; }

    public void Intialise(TrainState startingState)
    {
        CurrentState = startingState;
        CurrentState.Enter();
    }

    public void ChangeState(TrainState newState)
    {
        CurrentState.Exit();
        CurrentState = newState;
        CurrentState.Enter();
    }
}
