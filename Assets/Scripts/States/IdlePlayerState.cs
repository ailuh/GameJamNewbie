using Game;
using UnityEngine;

namespace States
{
    public class IdlePlayerState : PlayerState
    {
        public IdlePlayerState(PlayerController playerController, StateMachine stateMachine) : base(playerController, stateMachine)
        {
            
        }
        
        public override void UpdateState()
        {
            var grounded = playerController.IsSurfaceOverlapped();
            if (!grounded) stateMachine.ChangeState(playerController.Jumping);
            playerController.Rb.velocity = Vector2.zero;
            if (playerController.IsJumpInput) stateMachine.ChangeState(playerController.Jumping);
            if (playerController.IsWalkInput) stateMachine.ChangeState(playerController.Walking);
        }
        
    }
}