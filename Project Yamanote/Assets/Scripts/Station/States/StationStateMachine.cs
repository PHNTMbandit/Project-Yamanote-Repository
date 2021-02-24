namespace ProjectYamanote.Station
{
    public class StationStateMachine
    {
        public StationState CurrentState { get; set; }

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