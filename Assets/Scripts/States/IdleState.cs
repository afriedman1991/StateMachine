using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : BaseState
{
    public override void StateUpdate()
    {
        var input = state.PlayerInput;

        if (input.magnitude >= 0.05f)
        {
            state.ChangeState<MovementState>();
        }

        //if (Input.GetButtonDown("Fire1"))
        //{
        //    state.ChangeState<ShootingState>();
        //}

        if (Input.GetButtonDown("Fire2"))
        {
            state.ChangeState<GrappleState>();
        }

        if (Input.GetButtonDown("Aim2"))
        {
            state.ChangeState<AimingState>();
        }

        if (Input.GetButtonDown("Jump"))
        {
            state.ChangeState<JumpState>();
        }

        if (Input.GetButtonDown("Punch"))
        {
            state.ChangeState<AttackState>();
        }
    }

    public override void StateExit()
    {
        //Debug.Log("Exited Idle State");
    }

    public override void StateEnter()
    {
        //Debug.Log("Entered Idle StateEnter");
        //((PlayerStateMachine)state).playerRenderer.material.color = Color.red;
        //Player.lookAt

        state.characterAnimation.SetBool("isAiming", false);
        state.characterAnimation.SetBool("isWalking", false);
    }
}

// start with GDD, figure out your game loop too, the machanics involved
// two bounds, outer radius, and inner radius (outer where they start to slow down, and inner where they stop, lerping for x-units in and slowing until a certain point)
