using States;
using UnityEngine;

public class DisableInputState : PlayerState
{
    public DisableInputState(PlayerController playerController, StateMachine stateMachine) : base(playerController, stateMachine)
    {
    }
    
    public override void OnEnter()
    {
        playerController.Rb.velocity = Vector2.zero;
    }
    
    public override void OnExit()
    {
        
    }
}
