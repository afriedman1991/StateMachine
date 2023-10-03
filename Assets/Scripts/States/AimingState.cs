using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimingState : BaseState
{
    [SerializeField] Animator characterAnimation;

    public override void StateUpdate()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            state.ChangeState<ShootingState>();
        }

        if (Input.GetButtonDown("Fire2"))
        {
            state.ChangeState<GrappleState>();
        }

        if (Input.GetButtonUp("Aim2"))
        {
            state.ChangeState<IdleState>();
        }
    }

    public override void StateEnter()
    {
        Debug.LogWarning("Entering aiming state");
        characterAnimation.SetBool("isAiming", true);
    }

    public override void StateExit()
    {
        //characterAnimation.SetBool("isAiming", false);
    }
}
