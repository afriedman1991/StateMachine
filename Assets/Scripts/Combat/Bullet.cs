using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Bullet factory
public class Bullet : MonoBehaviour
{
    public Bullet MakeBullet(Vector3 pos, Vector3 firingDirection, float angleSpread = 0)
    {
        float yaw = Random.Range(-angleSpread, angleSpread);
        float pitch = Random.Range(-angleSpread, angleSpread);
        Quaternion firingCone = Quaternion.Euler(pitch, yaw, 0f);
        Bullet bullet = Instantiate(this, pos, Quaternion.identity);

        firingDirection = firingCone * firingDirection;

        bullet.GetComponent<Rigidbody>().velocity = firingDirection;

        Debug.DrawRay(pos, firingDirection, Color.green, 5f);

        Destroy(bullet, 10f); //Destroy happens after "bullet" has been returned
        return bullet;
    }
}
