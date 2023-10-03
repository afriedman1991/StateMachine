using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Look up components in Unity
// BULLET TIME MECHANIC, wait for time, then go back to idle, move constantly over a certain distance
    // This will have input, releasing the button will cancel the "shield"

public class MovementState : BaseState
{
    [SerializeField] private float speed = 10f;

    public override void StateUpdate()
    {
        // Get axis changes over time, get axis raw is immediate
        //transform.Translate(state.PlayerInput * Time.deltaTime * speed);
        state.MoveCamera(state.CameraInput, speed);

        if (state.PlayerInput.magnitude <= 0.05f)
        {
            state.ChangeState<IdleState>();
        }

        if (Input.GetButtonDown("Fire1"))
        {
            state.ChangeState<AttackState>();
        }

        if (Input.GetButtonDown("Jump"))
        {
            state.ChangeState<JumpState>();
        }
    }

    public override void StateExit()
    {
    }

    public override void StateEnter()
    {
        //((PlayerStateMachine)state).playerRenderer.material.color = Color.red;
        state.characterAnimation.SetBool("isWalking", true);
    }
}
