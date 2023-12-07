using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpGun : TriggerZone
{
    public BoxCollider coll;
    public WeaponData weaponData;

    public override void OnInteractedWith(Collider who)
    {
        Debug.Log("In On Trigger Stay");
        Gun weapon = who.transform.GetComponentInParent<Gun>();
        weapon.Equip(weaponData);
        Destroy(gameObject);
    }
}
