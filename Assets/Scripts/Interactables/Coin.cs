using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : TriggerZone
{
    [SerializeField] string item;

    private Vector3 rotationSpeed = new Vector3(0f, 100f, 0f);

    protected override void Update()
    {
        transform.Rotate(rotationSpeed * Time.deltaTime);
    }

    public override void OnZoneEntered(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("Trigger Enter Coin");
            OnInteract(other);
            Destroy(this);
        }
    }
}
