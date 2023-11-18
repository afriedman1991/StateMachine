using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "WeaponItem", menuName = "ScriptableObjects/WeaponObj")]
public class WeaponData : ScriptableObject
{
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

    public void InstantiateWorldGun()
    {
        Instantiate(worldModel, spawnLocations[0].transform.position, Quaternion.identity);
    }

    public void InstantiateEquipModel(Transform gunContainer)
    {
        GameObject equipGun = Instantiate(equipModel, gunContainer.position, Quaternion.identity);

        equipGun.transform.SetParent(gunContainer);
        equipGun.transform.localPosition = Vector3.zero;
        equipGun.transform.localRotation = Quaternion.identity;
    }
}
