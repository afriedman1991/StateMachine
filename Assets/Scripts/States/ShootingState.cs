using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingState : BaseState
{
    [SerializeField] Animator characterAnimation;

    public override void StateUpdate()
    {
    }

    public override void StateEnter()
    {
        characterAnimation.Play("Shooting");

        state.WaitForSeconds(2f, () =>
        {
            state.ChangeState<AimingState>();
        });
    }
}
