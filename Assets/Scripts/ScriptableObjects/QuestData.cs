using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "QuestData", menuName = "ScriptableObjects/QuestData")]
public class QuestData : ScriptableObject
{
    public Quest questAsset;
    public string description;

    public Quest InstantiateQuest()
    {
        Quest instantiatedQuest = Instantiate(
            questAsset, questAsset.transform.position, Quaternion.identity);

        return instantiatedQuest;
    }

    [ContextMenu("start quest")]
    public void StartQuest()
    {
        // point to quest asset
        // start quest
        Quest quest = Instantiate(questAsset);

        // reading data from the quest (like displaying in GUI)
        quest.StartTask(PlayerPrefs.GetInt(this.name, 0));
    }

    public void UpdateQuest(int currentTask)
    {
        // PlayerPrefs
        PlayerPrefs.SetInt($"{this.name}", currentTask);
    }
}
