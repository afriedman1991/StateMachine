using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApproachTask : Task
{
    public TriggerZone targetZone;

    public override void StartTask()
    {
        targetZone.OnInteract += Interact;
        //targetZone.OnInteract += (obj) => EndTask();
    }

    public override void EndTask()
    {
        Debug.Log("Task Completed");
    }

    public void Interact(Object objectName) => EndTask();
}
