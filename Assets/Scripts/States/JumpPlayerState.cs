using Game;
using UnityEngine;

namespace States
{
    public class JumpPlayerState : PlayerState
    {
        private bool _grounded;
        private Vector2 _vecGravity;
        private float _jumpTimer;
        private float _preventJumpBugTimer;
        private readonly float _fallMultiplier = 3;
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
            if (_jumpTimer > 0) _jumpTimer -= Time.deltaTime;
            if (_preventJumpBugTimer > 0) _preventJumpBugTimer -= Time.deltaTime;
            _grounded = playerController.IsSurfaceOverlapped();
            if ((_grounded && _jumpTimer <= 0) || (_preventJumpBugTimer <= 0))
            {
                stateMachine.ChangeState(playerController.Idle);
            }
        }
        
        public override void OnPhysicsUpdate()
        {
            if (playerController.Rb.velocity.y > 0)
               playerController.Rb.velocity -= _vecGravity * (_fallMultiplier * Time.deltaTime);
            if (playerController.Rb.velocity.y < 0)
                playerController.Rb.velocity -= _vecGravity * (_fallMultiplier * Time.deltaTime);
        }
        
        public override void OnExit()
        {
            playerController.Rb.velocity = Vector2.zero;
        }

        private void Jump()
        {
            playerController.PlaySoundJump();
            _jumpTimer = 0.3f;
            _preventJumpBugTimer = 2f;
            _grounded = false;
            var jumpValue = Mathf.Clamp(playerController.JumpValue, 0, 1);
            playerController.Rb.velocity = new Vector2(playerController.Rb.velocity.x, jumpValue * 20);
        }
    }
}
