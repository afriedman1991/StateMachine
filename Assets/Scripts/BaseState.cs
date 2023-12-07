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

    // find a specific list of objects or types within a radius from point
    public List<MonoBehaviour> Scan(Vector3 pos, float radius, int layerMask)
    {
        List<MonoBehaviour> colliderFilter = new List<MonoBehaviour>();
        Collider[] coll = Physics.OverlapSphere(pos, radius, layerMask);

        for (int i = 0; i < coll.Length; i++)
        {
            MonoBehaviour behaviour = coll[i].GetComponentInParent<MonoBehaviour>();
            // check every collider that's been in this radius with a directional filter
            if (behaviour != null)
            {
                colliderFilter.Add(behaviour);
            }
        }

        return colliderFilter;
    }

    // find a specific list of objects or types within a radius from point
    public List<T> ScanForType<T>(Vector3 pos, float radius, int layerMask)
    {
        List<T> colliderFilter = new List<T>();
        Collider[] coll = Physics.OverlapSphere(pos, radius, layerMask);

        for (int i = 0; i < coll.Length; i++)
        {
            T behaviour = coll[i].GetComponentInParent<T>();
            // check every collider that's been in this radius with a directional filter
            if (behaviour != null)
            {
                colliderFilter.Add(behaviour);
            }
        }

        return colliderFilter;
    }

    public virtual void StateUpdate() { }

    public virtual void StateLateUpdate() { }

    public virtual void StateExit() { }

    public virtual void StateEnter() { }
}
