using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hurtable : Spawnable
{
    public int health = 100;
    public bool killed;

    public void OnDamaged(GameObject who)
    {
        health -= 50;
        Debug.Log("Taking damage");

        if (health <= 0)
        {
            // "this" is the script, gameObject is self descriptive
            Destroy(gameObject);

            OnKilled.Invoke(who);
        }
    }

    [ContextMenu("Damaged")]
    public void TestDamage()
    {
        OnDamaged(null);
    }

    private void OnMouseDown()
    {
        OnDamaged(null);
    }
}
