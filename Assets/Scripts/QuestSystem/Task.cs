using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Task : MonoBehaviour
{
    public Action TaskCompleted;

    public virtual void StartTask()
    {
        // Start a co-routine here for the task update-cycle
        // The update-cycle will keep track of the completion then call end task
        // Get the kill task completed
        // Collect item task

        StartCoroutine(Process());
    }

    public virtual void EndTask()
    {
        if (TaskCompleted != null) TaskCompleted.Invoke();

        TaskCompleted = null;
    }

    public IEnumerator Process()
    {
        yield return new WaitForSeconds(1f);
        EndTask();
        //while (true)
        //{

        //    yield return new WaitForEndOfFrame();
        //}
    }
}
