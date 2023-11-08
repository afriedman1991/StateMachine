using UnityEngine;

public class CollectCoinsTask : Task
{
    /* 
     * PlayerPrefs to make a flag system,
     * where object in game sets the flag in player prefs
     * and set that flag in interact zone to say that it's been collected
     */
    public ItemScriptableObject itemType;
    public int numberOfCoinsToCollect = 3;
    [SerializeField] private int coinsCollected = 0;

    public override void StartTask()
    {
        PickUp.OnPickUp += OnPickUp;
    }

    public override void EndTask()
    {
        PickUp.OnPickUp -= OnPickUp;
        base.EndTask();
    }

    private void OnPickUp(PickUp pickUp)
    {
        if (pickUp.itemType != itemType) return;

        coinsCollected++;
        gameObject.SetActive(false);

        if (coinsCollected == numberOfCoinsToCollect)
        {
            EndTask();

            Debug.Log("Coin Task Completed");
        }
    }
}
