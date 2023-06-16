using System;
using States;
using States.States;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] 
    private float checkRaduis;
    [SerializeField] 
    private TMP_Text stateText;
    [SerializeField] 
    private TMP_Text isGroundedText;
    [SerializeField] 
    private Transform groundCheck;
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
    public PlayerState Disabled;
    public bool isWalkInput => _isWalkInput;
    public bool isJumpInput=> _isJumpInput;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _stateMachine = new StateMachine();

        Walking = new WalkPlayerState(this, _stateMachine);
        Jumping = new JumpPlayerState(this, _stateMachine);
        Idle = new IdlePlayerState(this, _stateMachine);
        Disabled = new DisableInputState(this, _stateMachine);
        _stateMachine.Initialize(Idle);    
    }
    
    public void DisableInput()
    {
        _stateMachine.ChangeState(Disabled);
    }
    
    public void EnableInput()
    {
        _stateMachine.ChangeState(Idle);
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
        bool isOverlapped = Physics2D.OverlapCircle(groundCheck.position, checkRaduis,groundLayer);
        isGroundedText.text = isOverlapped.ToString();
        return isOverlapped;
    }
    
    
}
