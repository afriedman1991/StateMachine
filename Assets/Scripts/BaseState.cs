using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Starts at StateMachine, references other states and determines which state to call
public class BaseState : MonoBehaviour
{
    protected PlayerStateMachine state;
    protected Animator playerAnimations;

    public virtual void StatePhysicsUpdate() { }

    public void InitializeStateMachine(PlayerStateMachine currentState)
    {
        state = currentState;
    }

    public virtual void StateUpdate() { }

    public virtual void StateLateUpdate() { }

    public virtual void StateExit() { }

    public virtual void StateEnter() { }
}
