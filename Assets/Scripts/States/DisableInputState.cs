using Game;
using UnityEngine;

namespace States
{
    public class DisableInputState : PlayerState
    {
        public DisableInputState(PlayerController playerController, StateMachine stateMachine) : base(playerController, stateMachine)
        {
        }
    
        public override void OnEnter()
        {
            playerController.Rb.velocity = Vector2.zero;
        }
        
    }
}
