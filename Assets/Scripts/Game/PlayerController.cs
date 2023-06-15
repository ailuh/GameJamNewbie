using System.Collections;
using System.Collections.Generic;
using States;
using States.States;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private TMP_Text stateText;
    [SerializeField] private TMP_Text isGroundedText;
    [SerializeField] private Transform groundCheck;
    private bool _isWalkInput;
    private bool _isJumpInput;
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
    public bool isWalkInput => _isWalkInput;
    public bool isJumpInput=> _isJumpInput;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _stateMachine = new StateMachine();

        Walking = new WalkPlayerState(this, _stateMachine);
        Jumping = new JumpPlayerState(this, _stateMachine);
        Idle = new IdlePlayerState(this, _stateMachine);
        _stateMachine.Initialize(Idle);
    }

    private void Update()
    {
        _stateMachine.CurrentPlayerState.UpdateState();
        if (_isJumpInput) _isJumpInput = false;
        if (_isWalkInput) _isWalkInput = false;
        stateText.text = _stateMachine.CurrentPlayerState.ToString();
        IsSurfaceOverlapped();
    }

    private void FixedUpdate()
    {
        _stateMachine.CurrentPlayerState.OnPhysicsUpdate();
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        _moveDirection = context.ReadValue<Vector2>();
        _isWalkInput = true;
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        _jumpValue = context.ReadValue<float>();
        _isJumpInput = true;
    }
    
    public bool IsSurfaceOverlapped()
    {
        bool isOverlapped = Physics2D.OverlapCapsule(groundCheck.position, new Vector2(1.1f, 0.3f), CapsuleDirection2D.Horizontal,0,groundLayer);
        isGroundedText.text = isOverlapped.ToString();
        return isOverlapped;
    }
    
    
}
