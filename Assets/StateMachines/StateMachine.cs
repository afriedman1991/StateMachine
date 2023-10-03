using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// try adding a movement and/or dash state

public abstract class StateMachine : MonoBehaviour
{
    [SerializeField]
    private BaseState _currentState;

    private void Update()
    {
        _currentState?.StateUpdate();
    }

    private void LateUpdate()
    {
        _currentState?.StateLateUpdate();
    }

    private void FixedUpdate()
    {
        _currentState?.StatePhysicsUpdate();
    }

    public void ChangeState(BaseState newState)
    {
        if (_currentState == newState)
        {
            return;
        }

        _currentState?.StateExit();

        _currentState = newState;

        _currentState?.StateEnter();
    }

    public void ChangeState<T>() where T: BaseState
    {
        BaseState newState = GetComponentInChildren<T>();
        ChangeState(newState);
    }

    public void WaitForSeconds(float seconds, System.Action cb)
    {
        StartCoroutine(_waitForSeconds(seconds, cb));
    }

    private IEnumerator _waitForSeconds(float seconds, System.Action cb)
    {
        yield return new WaitForSeconds(seconds);
        cb.Invoke();
    }

    private void FrameData()
    {

    }

    private void AttackState()
    {
        // have this control animations, and process frame data as it goes through the attack, and return from attack (a one shot)
        // go into, process, exit, go back to state that called it (usually idle, when no other state is given) allow null, which makes it go back to previous state
        // keep track of how long does this attack lasts, start, end, return. Time based/frame based data. Can treat frame data as an animation
        // professional way would be to make your own frame data editor
        // Script called AnimationData that manages the IFrames, damage frames, collider frames, block frames
    }
}
