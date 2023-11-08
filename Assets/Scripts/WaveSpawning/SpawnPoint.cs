using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    // GameObject SpawnPoint will have this on it
    // This will have the Mob prefab to spawn
    //public Hurtable Mob;

    // This will take a transform to determine the location of the spawn point
    public Transform spawnPoint;

    // Will determine which mob to spawn
    public Spawnable whatToSpawn;

    public Spawnable Spawn(Transform origin)
    {
        // Determine relative position and rotation
        Vector3 relativePosition = GetPoint(origin);  // Assuming GetPoint computes the relative position
        Quaternion relativeRotation = Quaternion.Euler(GetRotation(origin.eulerAngles)); // Assuming GetRotation computes the relative rotation

        // Use Spawn method
        return whatToSpawn.Spawn(relativePosition, relativeRotation, origin);

        //var rot = origin.transform.localRotation;
        //var pos = transform.InverseTransformPoint(origin.transform.position);

        // Pass in new parameters that are relative to the origin
        // needs to know local position relative to the parent it's spawning under
        // take relative position from the root transform of the data and pass that in instead of transform
        // changes values of position and rotation relative to new owner (Transform owner)
        //return whatToSpawn.Spawn(pos, rot, owner);
    }

    public Vector3 GetPoint(Transform origin)
    {
        // changing from world space to local space, then back to world space
        // relative to new origin (the position of the asset)
        var localPosition = transform.root.InverseTransformPoint(transform.position);
        return
            origin.TransformPoint(
                localPosition
                );
    }

    public Vector3 GetRotation(Vector3 origin)
    {
        Vector3 spawnPointEulerAngles = spawnPoint.eulerAngles;
        return new Vector3(
            spawnPointEulerAngles.x - origin.x,
            spawnPointEulerAngles.y - origin.y,
            spawnPointEulerAngles.z - origin.z
        );
    }
}
