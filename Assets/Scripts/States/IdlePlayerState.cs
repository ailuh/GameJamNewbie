using Game;
using UnityEngine;

namespace States
{
    public class IdlePlayerState : PlayerState
    {
        private Animator _animator;
        private static readonly int IsRight = Animator.StringToHash("isRight");
        private static readonly int IsLeft = Animator.StringToHash("isLeft");
        
        public IdlePlayerState(PlayerController playerController, StateMachine stateMachine) : base(playerController, stateMachine)
        {
            _animator = playerController.GetComponent<Animator>();
        }

        public override void OnEnter()
        {
            _animator.SetBool(IsRight, false);
            _animator.SetBool(IsLeft, false);
        }

        public override void UpdateState()
        {
            var grounded = playerController.IsSurfaceOverlapped();
            //if () stateMachine.ChangeState(playerController.Jumping);
            playerController.Rb.velocity = Vector2.zero;
            if (playerController.IsJumpInput || !grounded) 
                stateMachine.ChangeState(playerController.Jumping);
            if (playerController.IsWalkInput) 
                stateMachine.ChangeState(playerController.Walking);
        }
        
    }
}