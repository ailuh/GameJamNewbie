    using Game;

namespace States
{
    using UnityEngine;

    namespace States
    {
        public class WalkPlayerState : PlayerState
        {
            private readonly float _moveSpeed = 5f;
            private Animator _animator;
            private static readonly int IsRight = Animator.StringToHash("isRight");
            private static readonly int IsLeft = Animator.StringToHash("isLeft");

            public WalkPlayerState(PlayerController playerController, StateMachine stateMachine) : base(playerController, stateMachine)
            {
                _animator = playerController.GetComponent<Animator>();
            }
            
            public override void UpdateState()
            {
                Move(playerController.MoveDirection);
                if(playerController.IsJumpInput || !playerController.IsSurfaceOverlapped())
                    stateMachine.ChangeState(playerController.Jumping);
                if (playerController.MoveDirection.Equals(Vector2.zero))
                    stateMachine.ChangeState(playerController.Idle);
                
            }
            
            private void Move(Vector2 direction)
            {
                if (direction.x > 0)
                {
                    playerController.transform.localScale = new Vector3(1, 1, 1);
                    _animator.SetBool(IsRight, true);
                    _animator.SetBool(IsLeft, false);
                }
                if (direction.x < 0)
                {   
                    playerController.transform.localScale = new Vector3(-1, 1, 1);
                    _animator.SetBool(IsRight, false);
                    _animator.SetBool(IsLeft, true);
                }
                playerController.Rb.velocity =_moveSpeed * new Vector3(direction.x, 0);
            }
        }
    }

}