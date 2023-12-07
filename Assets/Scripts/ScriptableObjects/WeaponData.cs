using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "WeaponItem", menuName = "ScriptableObjects/WeaponObj")]
public class WeaponData : ScriptableObject
{
    public string weaponType;
    public int ammoAmt;
    public int shotsPerSecond;
    public int maxClipSize;
    public int bulletsPerShot; // Implement this in WeaponModel.cs (essentially just a loop)

    public Vector2 recoilForce;
    public float angleSpread;
    public GameObject equipModel;
    public GameObject worldModel;
    public Transform[] spawnLocations;

    public Bullet bullet;
    public float projectileSpeed;
    public float chargeTime;
    public float reloadTime;
    public float damageMod;

    public void InstantiateWorldWeapon()
    {
        Instantiate(worldModel, spawnLocations[0].transform.position, Quaternion.identity);
    }

    public void InstantiateEquipWeapon(Transform weaponContainer)
    {
        Debug.Log($"Equip Weapon: {weaponContainer}");
        GameObject equipGun = Instantiate(equipModel, weaponContainer.position, Quaternion.identity);


        equipGun.transform.SetParent(weaponContainer);
        equipGun.transform.localPosition = Vector3.zero;
        equipGun.transform.localRotation = Quaternion.identity;
    }
}
