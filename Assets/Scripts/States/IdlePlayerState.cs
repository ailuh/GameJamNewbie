using UnityEngine;

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
            var grounded = playerController.IsSurfaceOverlapped();
            if (!grounded) stateMachine.ChangeState(playerController.Jumping);
            playerController.Rb.velocity = Vector2.zero;
            if (playerController.isJumpInput) stateMachine.ChangeState(playerController.Jumping);
            if (playerController.isWalkInput) stateMachine.ChangeState(playerController.Walking);
        }
        
        public override void OnExit()
        {
            
        }
    }
}