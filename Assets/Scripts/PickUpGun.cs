using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpGun : TriggerZone
{
    public BoxCollider coll;
    public WeaponData weaponData;
    [HideInInspector] private InteractableBehavior interactable;

    public override void OnInteractedWith(Collider who)
    {
        Debug.Log("In On Trigger Stay");
        Weapon weapon = who.transform.GetComponentInParent<Weapon>();
        weapon.Equip(weaponData);
        Destroy(gameObject);
    }
}
