using System.Linq;
using States;
using States.States;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Game
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private Transform groundCheck;
        private AudioSource _audioSource;
        public AudioClip jumpSound;
        private Vector2 _moveDirection;
        private float _jumpValue;
        private Rigidbody2D _rb;
        private StateMachine _stateMachine;
        public float JumpValue => _jumpValue;
        public Vector2 MoveDirection => _moveDirection;
        public Rigidbody2D Rb => _rb;
        public LayerMask groundLayer;
        public PlayerState Walking;
        public PlayerState Jumping;
        public PlayerState Idle;
        public PlayerState Disabled;
        private Animator _animator;
        private PlayerInput _playerInput;
        private static readonly int IsDied = Animator.StringToHash("isDied");
        public bool IsWalkInput { get; private set; }
        public bool IsJumpInput { get; private set; }

        private void Awake()
        {
            _rb = GetComponent<Rigidbody2D>();
            _animator = GetComponent<Animator>();
            _stateMachine = new StateMachine();
            _audioSource = GetComponent<AudioSource>();
            Walking = new WalkPlayerState(this, _stateMachine);
            Jumping = new JumpPlayerState(this, _stateMachine);
            Idle = new IdlePlayerState(this, _stateMachine);
            Disabled = new DisableInputState(this, _stateMachine);
            _stateMachine.Initialize(Idle);
            _playerInput = GetComponent<PlayerInput>();
        }

        public void DisableInput()
        {
            _playerInput.SwitchCurrentActionMap("UI");
            _stateMachine.ChangeState(Disabled);
        }

        public void EnableInput()
        {
            _playerInput.SwitchCurrentActionMap("Player");
            _animator.SetBool(IsDied, false);
            _stateMachine.ChangeState(Idle);
        }

        public void Die()
        {
            _animator.SetBool(IsDied, true);
        }

        private void Update()
        {
            _stateMachine.CurrentPlayerState.UpdateState();
            IsWalkInput = !_moveDirection.Equals(Vector2.zero);
            IsJumpInput = _jumpValue != 0;
            IsSurfaceOverlapped();
        }

        public void PlaySoundJump()
        {
            _audioSource.PlayOneShot(jumpSound);
        }

        private void FixedUpdate()
        {
            _stateMachine.CurrentPlayerState.OnPhysicsUpdate();
        }

        public void OnMove(InputAction.CallbackContext context)
        {
            _moveDirection = context.ReadValue<Vector2>();
        }

        public void OnJump(InputAction.CallbackContext context)
        {
            _jumpValue = context.ReadValue<float>();
        }
        
    public bool IsSurfaceOverlapped()
        {
            bool isOverlapped = Physics2D.OverlapCapsule(groundCheck.position, new Vector2(1.0f, 0.3f), CapsuleDirection2D.Horizontal,0, groundLayer);
            return isOverlapped;
        }
        
    }
}
