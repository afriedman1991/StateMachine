using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quest : MonoBehaviour
{
    private Task[] tasks;
    private int currentTaskIndex = 0;
    [SerializeField] private QuestData myQuest;

    private void Start()
    {
        tasks = GetComponentsInChildren<Task>();
        NextTask();
    }

    public void StartTask(int taskNum)
    {
        if (taskNum >= 0 && taskNum < tasks.Length)
        {
            Debug.Log($"current task at start task: {tasks[taskNum].name}");
            tasks[taskNum].StartTask();
            tasks[taskNum].TaskCompleted += NextTask;
        }
        else
        {
            Debug.Log("All tasks completed!");
            Destroy(gameObject);
        }
    }

    // this updates Quest/Task
    public void NextTask()
    {
        if (currentTaskIndex <= tasks.Length)
        {
            StartTask(currentTaskIndex++);
        }

        myQuest.UpdateQuest(currentTaskIndex);
    }
}
