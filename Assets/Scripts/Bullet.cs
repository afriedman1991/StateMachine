using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Bullet factory
public class Bullet : MonoBehaviour
{
    public Bullet MakeBullet(Vector3 pos, Quaternion firingAngle)
    {
        Bullet bullet = Instantiate(this, pos, firingAngle);

        bullet.GetComponent<Rigidbody>().velocity = firingAngle * Vector3.forward * 20f;

        Destroy(bullet, 10f); //Destroy happens after "bullet" has been returned
        return bullet;
    }
}
