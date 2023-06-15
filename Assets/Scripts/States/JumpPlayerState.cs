using States.States;
using UnityEngine;

namespace States
{
    public class JumpPlayerState : PlayerState
    {
        private bool _grounded;
        private Vector2 _vecGravity;
        private float _fallMultiplier = 3;
        public float _timeRemaning;
        public JumpPlayerState(PlayerController playerController, StateMachine stateMachine) : base(playerController, stateMachine)
        {
        }
        public override void OnEnter()
        {
            _vecGravity = new Vector2(0, -Physics2D.gravity.y);
            _grounded = false;
            Jump();
        }

        public override void UpdateState()
        {
        
            if (playerController.Rb.velocity.y < 0)
                playerController.Rb.velocity -= _vecGravity * _fallMultiplier * Time.deltaTime;
        }
        
        public override void OnPhysicsUpdate()
        {
            if (_timeRemaning > 0)
            {
                _timeRemaning -= Time.deltaTime;
            }
            else
            {
                _grounded = playerController.IsSurfaceOverlapped();
                if (_grounded)
                {
                    stateMachine.ChangeState(playerController.Idle);
                }
            }
           
        }
        
        public override void OnExit()
        {
            playerController.Rb.velocity = Vector2.zero;
        }

        private void Jump()
        {
            _timeRemaning = 0.5f;
            var jumpValue = playerController.JumpValue;
            playerController.Rb.velocity = new Vector2(playerController.Rb.velocity.x, jumpValue * 15);
            
        }
    }
}
