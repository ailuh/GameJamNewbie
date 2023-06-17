    using Game;

namespace States
{
    using UnityEngine;

    namespace States
    {
        public class WalkPlayerState : PlayerState
        {
            private readonly float _moveSpeed = 5f;
            public WalkPlayerState(PlayerController playerController, StateMachine stateMachine) : base(playerController, stateMachine)
            {
            }
            
            public override void UpdateState()
            {
                Move(playerController.MoveDirection);
                if(playerController.IsJumpInput)
                    stateMachine.ChangeState(playerController.Jumping);
                if (playerController.MoveDirection.Equals(Vector2.zero) || !playerController.IsSurfaceOverlapped())
                    stateMachine.ChangeState(playerController.Idle);
                
            }
            
            private void Move(Vector2 direction)
            {
                    playerController.Rb.velocity =_moveSpeed * new Vector3(direction.x, 0);

            }
        }
    }

}