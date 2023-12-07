using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class Bow : BaseWeapon
{
    private Quaternion whereToLook, spreadRotation, firingAngle;
    private Bullet bullet;

    public override void AttackHeld(float timeHeld)
    {
        whereToLook = Quaternion.LookRotation(
            weaponTip.transform.forward, Vector3.up);
        firingAngle = whereToLook;
    }

    public override void AttackReleased(float timeHeld)
    {
        if (timeHeld < weaponData.chargeTime)
        {
            return;
        }

        bullet = weaponData.bullet.MakeBullet(
            weaponTip.transform.position,
            weaponTip.transform.forward * weaponData.projectileSpeed,
            weaponData.angleSpread
        );
    }

    public override void AimHeld(bool timeHeld)
    {
        Debug.DrawRay(
            weaponTip.transform.position, firingAngle * Vector3.forward * weaponData.chargeTime, Color.red, 1f);

        animator.SetBool("isAiming", timeHeld);
    }
}
