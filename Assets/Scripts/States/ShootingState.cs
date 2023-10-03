using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingState : BaseState
{
    [SerializeField] Animator characterAnimation;

    public override void StateEnter()
    {
        characterAnimation.Play("Shooting");

        state.WaitForSeconds(1f, () =>
        {
            state.ChangeState<IdleState>();
        });
    }
}
