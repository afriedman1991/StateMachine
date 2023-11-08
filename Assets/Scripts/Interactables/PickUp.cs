using UnityEngine;
using UnityEngine.Events;

public class PickUp : InteractableBehavior, Interactable
{
    public ItemScriptableObject itemType;
    public static UnityAction<PickUp> OnPickUp;
    public override void OnInteract(Collider who)
    {
        if (who.gameObject.tag == "Player")
        {
            Debug.Log("Interacting with Coin");
            who.gameObject.GetComponentInParent<Inventory>().collectedItems.Add(gameObject);
            CollectedItem(gameObject.name, transform.parent.GetComponentInChildren<TriggerZone>().name);
            gameObject.SetActive(false);
        }
        Debug.Log("Interacting Coin");
    }

    public void CollectedItem(string itemName, string zoneName)
    {
        string key = $"{zoneName} {itemName} _collected";

        int currentCount = PlayerPrefs.GetInt(key, 0);

        PlayerPrefs.SetInt(key, currentCount + 1);

        PlayerPrefs.Save();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("Trigger Enter Coin");
            OnInteract(other);
            OnPickUp.Invoke(this);
        }
    }
}
