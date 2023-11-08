using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : InteractableBehavior, Interactable
{
    [SerializeField] Animator characterAnimation;

    public override void OnInteract(Collider who)
    {
        if (who.gameObject.tag == "Player")
            characterAnimation.Play("OpenDoor");
    }

    public override string GetToolTip()
    {
        return "Press 'Triangle' to open door";
    }
}
