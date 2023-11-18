using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpState : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] private BoxCollider coll;
    [SerializeField] private Transform player, gunContainer, cam;

    [SerializeField] private float pickUpRange;
    [SerializeField] private float dropForwardForce, dropUpwardForce;

    [SerializeField] private bool equipped;
    [SerializeField] private static bool slotFull;

    private void PickUp()
    {

    }

    private void Drop()
    {

    }
}
