using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : BaseWeapon
{
    private Quaternion whereToLook, spreadRotation, firingAngle;
    private Bullet bullet;

    //public override void AttackHeld(float timeHeld)
    //{
    //    float yaw = Random.Range(-weaponData.angleSpread, weaponData.angleSpread);
    //    float pitch = Random.Range(-weaponData.angleSpread, weaponData.angleSpread);

    //    whereToLook = Quaternion.LookRotation(
    //        weaponTip.transform.forward, Vector3.up);
    //    spreadRotation = Quaternion.Euler(pitch, yaw, 0f);
    //    firingAngle = whereToLook * spreadRotation;

    //    Debug.DrawRay(
    //        weaponTip.transform.position, firingAngle * Vector3.forward * weaponData.chargeTime, Color.red, 1f);
    //}
}
