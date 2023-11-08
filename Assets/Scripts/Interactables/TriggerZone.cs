using System;
using UnityEngine;

public class TriggerZone : MonoBehaviour
{
    [SerializeField] private InteractableBehavior interactable;
    private Collider who;
    public Action<UnityEngine.Object> OnInteract;

    // On Trigger Stay, check the button every frame
    // On trigger enter, check every frame "have I pressed 'X' yet?"
    private void Awake()
    {
        interactable = transform.parent.GetComponentInChildren<InteractableBehavior>();
    }

    public void Update()
    {
        if (who != null && Input.GetButtonDown("Interact"))
        {
            Debug.Log($"Interacted with Trigger Zone {name}", this);
            interactable?.OnInteract(who);
            OnInteract?.Invoke(interactable.gameObject);
        }
    }

    public void OnTriggerExit(Collider who)
    {
        this.who = null;
    }

    public void OnTriggerEnter(Collider who)
    {
        this.who = who;
        Debug.Log($"Entered {name}");
        Debug.Log(interactable?.GetToolTip());
    }
}

//See stats for spread radius, recoil, data should determine if it's a prefab bullet or if its a raycast bullet
//Enum mask is a possibility
