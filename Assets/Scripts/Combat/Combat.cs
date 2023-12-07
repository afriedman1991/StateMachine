using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Tilemaps.Tile;

public class Combat : MonoBehaviour
{
    [SerializeField] private HashSet<Collider> blockActions;
    [SerializeField] private HashSet<Collider> damageActions;

    private void Awake()
    {
        blockActions = new HashSet<Collider>();
        damageActions = new HashSet<Collider>();
    }

    private void LateUpdate()
    {
        foreach(var c in blockActions)
        {
            damageActions.Remove(c);
            OnBlocked();
        }

        foreach(var c in damageActions)
        {
            OnDamaged();
        }

        blockActions.Clear();
        damageActions.Clear();
    }

    // Can use OnTriggerStay to take damage while colliders are in the damage collider
    //private void OnTriggerEnter(Collider col)
    //{
    //    var collision = col.GetComponent<CombatCollision>();
    //    Debug.Log($"Collider in CombatCollision Layer: {collision.gameObject.layer}, game object: {collision.gameObject}");

    //    if (collision == null)
    //    {
    //        return;
    //    }

    //    var colliderType = collision.colliderType;

    //    //var col = collision.collider;
    //    switch (colliderType)
    //    {
    //        case ColliderType.block:
    //            AddBlock(col);
    //            break;

    //        case ColliderType.damage:
    //            AddDamage(col);
    //            break;
    //    }
    //}

    public void AddDamage(Collider damageCollider)
    {
        damageActions.Add(damageCollider);
    }

    public void AddBlock(Collider blockCollider)
    {
        blockActions.Add(blockCollider);
    }

    private void OnBlocked()
    {
        // Would tell the attacker they've been blocked, which would start a visual and/or sound effect/animation
        Debug.Log("Blocked", gameObject);
    }

    private void OnDamaged()
    {
        // Would tell the attacker they've been attacked, which would start a visual and/or sound effect/animation, reduce character health
        Debug.Log("Damaged", gameObject);
    }
}
