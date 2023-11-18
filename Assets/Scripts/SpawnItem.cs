using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnItem : MonoBehaviour
{
    [SerializeField] private WeaponData weapon;

    void Start()
    {
        weapon.InstantiateWorldGun();
    }
}
