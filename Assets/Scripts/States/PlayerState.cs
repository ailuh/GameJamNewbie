using Game;

namespace States
{
    public abstract class PlayerState
    {
        protected readonly PlayerController playerController;
        protected readonly StateMachine stateMachine;
        
        protected PlayerState(PlayerController playerController, StateMachine stateMachine)
        {
            this.playerController = playerController;
            this.stateMachine = stateMachine;
        }
        
        public virtual void OnEnter()
        {
        }

        public virtual void UpdateState()
        {
        
        }

        public virtual void OnPhysicsUpdate()
        {
        
        }
        
        public virtual void OnExit()
        {
        
        }
    
    }
}