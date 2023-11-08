using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public abstract class Spawnable : MonoBehaviour
{
    // protected means only decendents of this class can access this
    public Action<UnityEngine.Object> OnKilled;

    public Spawnable Spawn(Vector3 worldPos, Quaternion worldRot, Transform parent)
    {
        Spawnable who = Instantiate(this, worldPos, worldRot, parent);

        return who;
    }
}

/**
 * Look at transform documentation:
 *  It has a few functions to help me figure out relative space to change the transform
 **/

/**
 * add enemy ai that follows the player
 * No access to inspector stuff when instantiating an object
 * Will have to find references to the player in ai script or when the game is running
 * Can make it "composable",
 *  with a targetable monobehavior (a tagging component,
 *  anything you want to be targatable to the enemy)
 *  on an object (the player) with a triggerable collider
 **/
