using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillTask : Task
{
    public WaveSpawner waves;

    public override void StartTask()
    {

    }

    public override void EndTask()
    {
        Debug.Log("Kill task has been completed");

        EndTask();
    }
}
