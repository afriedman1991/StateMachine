using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

interface Interactable
{
    public void OnInteract(Collider other);
    public string GetToolTip();
}

public abstract class InteractableBehavior : MonoBehaviour, Interactable
{
    public virtual void OnInteract(Collider other) { }
    public Action Interact;

    public virtual string GetToolTip()
    {
        return "Press 'Triangle' to interact";
    }
}
  