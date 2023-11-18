using UnityEngine;
using UnityEngine.Events;

public class PickUp : InteractableBehavior, Interactable
{
    public Transform player, gunContainer;
    public ItemScriptableObject itemType;
    public static UnityAction<PickUp> OnPickUp;
    public Rigidbody rb;
    public BoxCollider coll;

    public bool equipped;
    public bool slotFull;

    public float pickUpRange;
    public float dropDownwardForce, dropUpwardForce;

    private void Start()
    {
        if (!equipped)
        {
            rb.isKinematic = false;
            coll.isTrigger = false;
            slotFull = false;
        }
        if (equipped)
        {
            rb.isKinematic = true;
            coll.isTrigger = true;
            slotFull = true;
        }
    }

    public override void OnInteract(Collider who)
    {
        if (who.gameObject.tag == "Player")
        {
            Debug.Log("Interacting with Coin");
            who.gameObject.GetComponentInParent<Inventory>().collectedItems.Add(gameObject);
            CollectedItem(gameObject.name, transform.parent.GetComponentInChildren<TriggerZone>().name);
            gameObject.SetActive(false);
        }

        Vector3 distanceToPlayer = player.position - transform.position;
        if (itemType.itemDescription == "Gun" && !equipped &&
            distanceToPlayer.magnitude <= pickUpRange && !slotFull &&
            Input.GetButtonDown("Interact"))
        {
            PickUpItem();
        }

        if (equipped && Input.GetButtonDown("Drop"))
        {
            Drop();
        }
        Debug.Log("Interacting Coin");
    }

    private void PickUpItem()
    {
        equipped = true;
        slotFull = true;

        transform.SetParent(gunContainer);
        transform.localPosition = Vector3.zero;
        //transform.localRotation = Quaternion.Euler(Vector3.zero);

        rb.isKinematic = true;
        coll.enabled = false;
    }

    private void Drop()
    {
        equipped = false;
        slotFull = false;

        transform.SetParent(null);

        rb.isKinematic = false;
        coll.isTrigger = false;

        rb.velocity = player.GetComponent<Rigidbody>().velocity;

        rb.AddForce(player.forward * dropDownwardForce, ForceMode.Impulse);
        rb.AddForce(player.up * dropUpwardForce, ForceMode.Impulse);

        //float random = Random.Range(-1f, 1f);
        //rb.AddTorque(new Vector3(random, random, random) * 10);
    }

    public void CollectedItem(string itemName, string zoneName)
    {
        string key = $"{zoneName} {itemName} _collected";

        int currentCount = PlayerPrefs.GetInt(key, 0);

        PlayerPrefs.SetInt(key, currentCount + 1);

        PlayerPrefs.Save();
    }
}
