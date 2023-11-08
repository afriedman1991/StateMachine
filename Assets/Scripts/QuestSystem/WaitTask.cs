using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaitTask : Task
{
    public float waitForSeconds = 2f;

    public override void StartTask()
    {
        TaskCompleted += LogTaskComplete;

        StartCoroutine(Wait());
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(waitForSeconds);
        Debug.Log("Waiting Completed");

        EndTask();
    }

    public override void EndTask()
    {
        base.EndTask();
        StopAllCoroutines();
    }

    private void LogTaskComplete()
    {
        Debug.Log("Wait Task completed");
    }
}
