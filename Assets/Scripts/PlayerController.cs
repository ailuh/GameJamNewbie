using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

    public class PlayerController : MonoBehaviour
{ 
    private Vector2 _moveDirection;
    private float _moveSpeed = 1f;
    private float _jumpValue;
    private Rigidbody2D _rb;
    private Vector2 _vecGravity;
    private float _fallMultiplier = 30f;

    private void Start()
    {
        _vecGravity = new Vector2(0, -Physics2D.gravity.y);
        _rb = GetComponent<Rigidbody2D>();
        
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        _moveDirection = context.ReadValue<Vector2>();
    }
    
    public void OnJump(InputAction.CallbackContext context)
    {
        _jumpValue = context.ReadValue<float>();
    }
    
    private void Move(Vector2 direction)
    {
        var scaledMoveSpeed = _moveSpeed * Time.deltaTime;
        transform.position += scaledMoveSpeed * new Vector3(direction.x, 0, 0);
    }
    
    private void Jump(float jumpValue)
    {
        _rb.velocity = new Vector2(_rb.velocity.x, jumpValue * 10);
        if (jumpValue == 0)
        {
            _rb.velocity -= _vecGravity * _fallMultiplier * Time.deltaTime;
        }
    }
    
    private void Update()
    {
        Move(_moveDirection);
        Jump(_jumpValue);
    }
}
