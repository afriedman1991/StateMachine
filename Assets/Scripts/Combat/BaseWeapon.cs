using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Make a weapon slot script that can find and equip your weapons based on class name
/// based on numbers 1, 2, 3, 4 etc...
/// </summary>

public abstract class BaseWeapon : MonoBehaviour
{
    [SerializeField] protected Transform player;
    [SerializeField] protected Animator animator;
    [SerializeField] protected WeaponData weaponData;
    [SerializeField] protected Transform weaponTip;
    [SerializeField] protected bool canFire = true;
    [SerializeField] protected float timeBetweenShots = 5f;
    [SerializeField] protected Transform weaponContainer;

    private float timeHeld = 0f;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        weaponContainer = GameObject.FindGameObjectWithTag("GunContainer").transform;
        animator = player.GetComponentInChildren<Animator>();
    }

    protected virtual void Update()
    {
        HandleAttack();
        //UpdateCooldown();
        AimHeld(Input.GetButton("Aim2"));
    }

    protected void HandleAttack()
    {
        if (canFire && Input.GetButton("Fire1"))
        {
            AttackHeld(timeHeld);

            timeHeld += Time.deltaTime;
        }

        if (Input.GetButtonUp("Fire1"))
        {
            AttackReleased(timeHeld);
            timeHeld = 0f;
        }
    }

    protected void UpdateCooldown()
    {
        timeBetweenShots -= Time.deltaTime;
        if (timeBetweenShots <= 0)
        {
            canFire = true;
            timeBetweenShots = 1f / weaponData.shotsPerSecond;
        }
        else
        {
            canFire = false;
        }
    }

    public virtual void AttackHeld(float timeHeld) { }

    public virtual void AttackReleased(float timeHeld) { }


    public virtual void AimHeld(bool held) { }

    public virtual void Equip(WeaponData character)
    {
        Debug.Log("Equipping weapon in Weapon.cs");
        character.InstantiateEquipWeapon(weaponContainer);
    }

    public virtual Bullet FireBullet()
    {
        return weaponData.bullet.MakeBullet(
            weaponTip.transform.position, weaponTip.forward * weaponData.projectileSpeed, weaponData.angleSpread);
    }
}
