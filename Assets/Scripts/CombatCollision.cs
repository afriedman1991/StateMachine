using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ColliderType
{
    none,
    damage,
    block,
    hit
}

public class CombatCollision : MonoBehaviour
{
    private Combat combat;
    public ColliderType colliderType;
    public int damage;
    public int hitAbsorbsion;

    private void Awake()
    {
        combat = GetComponentInParent<Combat>();
    }

    private void OnTriggerEnter(Collider col)
    {
        var collision = col.GetComponent<CombatCollision>();

        if (col.transform.parent == this.gameObject.transform.parent)
        {
            return;
        }
        Debug.Log($"<Color=Red>{gameObject.name}</Color> has hit by: <Color=White>{collision.transform.parent.name}</Color> by collider <Color=Green>{col.name}</Color>", gameObject);

        if (collision == null)
        {
            return;
        }

        var colliderType = collision.colliderType;

        //var col = collision.collider;
        switch (colliderType)
        {
            case ColliderType.block:
                combat.AddBlock(col);
                break;

            case ColliderType.damage:
                combat.AddDamage(col);
                break;
        }
    }
}
