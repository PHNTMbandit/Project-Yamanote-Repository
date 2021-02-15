namespace ProjectYamanote.Station.States
{
    public class StationStateMachine
    {
        public StationState CurrentState { get; private set; }

        public void Initialise(StationState startingState)
        {
            CurrentState = startingState;
            CurrentState.Enter();
        }

        public void ChangeState(StationState newState)
        {
            CurrentState.Exit();
            CurrentState = newState;
            CurrentState.Enter();
        }
    }
}