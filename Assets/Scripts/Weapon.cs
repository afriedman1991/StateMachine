using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private WeaponData weapon; // This is the data object for weapons
    [SerializeField] private float timeBetweenShots = 5f;
    [SerializeField] private Transform gunTip;
    [SerializeField] private Transform gunContainer;
    [SerializeField] private Transform player;

    public float pickUpRange;
    public float dropForwardForce, dropUpwardForce;

    private bool canFire = true;

    private void Start()
    {
        gunContainer = GameObject.FindGameObjectWithTag("GunContainer").transform;
    }

    private void Update()
    {
        if (canFire && Input.GetButton("Fire1"))
        {
            FireGun(transform.position, transform.forward);
        }

        timeBetweenShots -= Time.deltaTime;

        if (timeBetweenShots <= 0)
        {
            canFire = true;

            // reset the time
            timeBetweenShots = 1f / weapon.shotsPerSecond;
        }
        else
        {
            canFire = false;
        }
    }


    // variable last time stamp = Time.time
    // variable delay which keeps track of the current time - the time stamp
    // if delay > shot delay, then start shooting, set the last timestamp to current time

    private void FireGun(Vector3 pos, Vector3 normalDirection)
    {
        // Set angle, distance, and direction of bullet (trigonometry way, finding a cone)
        float yaw = Random.Range(-weapon.angleSpread, weapon.angleSpread);
        float pitch = Random.Range(-weapon.angleSpread, weapon.angleSpread);

        Quaternion whereToLook = Quaternion.LookRotation(normalDirection, Vector3.up);
        Quaternion spreadRotation = Quaternion.Euler(pitch, yaw, 0f);
        Quaternion firingAngle =  whereToLook * spreadRotation;

        Debug.DrawRay(pos, firingAngle * Vector3.forward * 20f, Color.red, 1f);

        Bullet bullet = weapon.bullet.MakeBullet(pos, firingAngle);
        //bullet.GetComponent<Rigidbody>().velocity = firingAngle * Vector3.forward * 20f;

        // if cool down timer is <= 0, reset the cool downtimer
    }

    public void Equip(WeaponData weaponItem)
    {
        weaponItem.InstantiateEquipWeapon(gunContainer);
        gunTip = GameObject.FindGameObjectWithTag("GunTip").transform;
    }

    public void Drop(WeaponData weaponItem)
    {
        weaponItem.InstantiateWorldWeapon();
        Rigidbody rb = GetComponent<Rigidbody>();

        rb.velocity = player.GetComponent<Rigidbody>().velocity;

        rb.AddForce(player.forward * 15f, ForceMode.Impulse);
        rb.AddForce(player.up * dropUpwardForce, ForceMode.Impulse);
    }
}
