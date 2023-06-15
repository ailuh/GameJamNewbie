namespace States
{
    public class IdlePlayerState : PlayerState
    {
        public IdlePlayerState(PlayerController playerController, StateMachine stateMachine) : base(playerController, stateMachine)
        {
            
        }

        public override void OnEnter()
        {
            
        }

        public override void UpdateState()
        {
            if (playerController.isJumpInput) stateMachine.ChangeState(playerController.Jumping);
            if (playerController.isWalkInput) stateMachine.ChangeState(playerController.Walking);
        }
        
        public override void OnExit()
        {
            
        }
    }
}