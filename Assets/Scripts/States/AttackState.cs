using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : BaseState
{
    //[SerializeField] Renderer playerRenderer;
    [SerializeField] Animator characterAnimation;

    public override void StateExit()
    {
        //Debug.Log("Exited Attack State");
    }

    public override void StateEnter()
    {
        //Debug.Log("Entered Attack StateEnter");
        characterAnimation.SetBool("isAttacking", true);

        //((PlayerStateMachine)state).playerRenderer.material.color = Color.yellow;
        characterAnimation.Play("NewPunching");

        state.WaitForSeconds(.1f, () =>
        {
            characterAnimation.SetBool("isAttacking", false);
            state.ChangeState<IdleState>();
        });
    }
}

// only agents can trigger bullet time when dodging (have this so that all mechanics are core)
// the focus meter has to be built up to use focus abilities
// telegraph your attacks for enemies, can randomize time for attacks
