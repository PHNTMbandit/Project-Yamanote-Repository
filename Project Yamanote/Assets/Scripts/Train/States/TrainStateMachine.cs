namespace ProjectYamanote.Train.States
{
    public class TrainStateMachine
    {
        public TrainState CurrentState { get; set; }

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
}