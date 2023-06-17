namespace States
{
    public class StateMachine
    {
        public PlayerState CurrentPlayerState { get; private set; }

        public void Initialize(PlayerState startingPlayerState)
        {
            CurrentPlayerState = startingPlayerState;
            startingPlayerState.OnEnter();
        }

        public void ChangeState(PlayerState newPlayerState)
        {
            CurrentPlayerState.OnExit();
            CurrentPlayerState = newPlayerState;
            newPlayerState.OnEnter();
        }
    }
}
