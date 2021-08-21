using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class that contains data of a quest
/// </summary>
[System.Serializable]
public class DataQuest : BaseData
{

    /// <summary>
    /// Quest description
    /// </summary>
    public string description;

    /// <summary>
    /// Appear condition of this quest
    /// </summary>
    public int appearLevel;

    /// <summary>
    /// objectifs of this quest
    /// </summary>
    public List<QuestObjectif> objectifs = new List<QuestObjectif>();

    /// <summary>
    /// rewards of this quest
    /// </summary>
    public List<PlayerReward> rewards = new List<PlayerReward>();

    /// <summary>
    /// Fonction to test condition if this quest can appear iingame
    /// </summary>
    /// <returns></returns>
    public bool ConditionOk()
    {
        return GameManager.dataSave.player.level >= appearLevel;
    }

    /// <summary>
    /// Fonctin to test if all ojectif are ok
    /// </summary>
    /// <returns></returns>
    public bool ObjectifOk()
    {
        int nbOk = 0;

        for (int i = 0, length = objectifs.Count; i < length; i++)
        {
            switch ((DataEnum.ObjectifTipe)objectifs[i].objectif)
            {
                case DataEnum.ObjectifTipe.TalkToNumberNpc:
                    objectifs[i].objectifResult = GameManager.dataSave.player.npcTalkTo.Count >= objectifs[i].parameter;
                    break;
                case DataEnum.ObjectifTipe.BuyItem:
                    objectifs[i].objectifResult = GameManager.dataSave.player.itemBuy.Contains(objectifs[i].parameter);
                    break;
                case DataEnum.ObjectifTipe.UseItem:
                    objectifs[i].objectifResult = GameManager.dataSave.player.itemUse.Contains(objectifs[i].parameter);
                    break;
                case DataEnum.ObjectifTipe.BuyNumberItem:
                    objectifs[i].objectifResult = GameManager.dataSave.player.itemBuy.Count >= objectifs[i].parameter;
                    break;
                case DataEnum.ObjectifTipe.UseNumberItem:
                    objectifs[i].objectifResult = GameManager.dataSave.player.itemUse.Count >= objectifs[i].parameter;
                    break;
                case DataEnum.ObjectifTipe.TalkToNpc:
                    objectifs[i].objectifResult = GameManager.dataSave.player.npcTalkTo.Contains(objectifs[i].parameter);
                    break;
                case DataEnum.ObjectifTipe.GetNumberWork:
                    objectifs[i].objectifResult = GameManager.dataSave.player.playerJobs.Count >= objectifs[i].parameter;
                    break;
                case DataEnum.ObjectifTipe.GetWorkAt:
                    objectifs[i].objectifResult = GameManager.dataSave.player.playerJobs.Contains(objectifs[i].parameter);
                    break;
            }

            if (objectifs[i].objectifResult)
                nbOk++;
        }



        return nbOk >= objectifs.Count;
    }

    /// <summary>
    /// Fonction to reward the player when completed this quest
    /// </summary>
    public void RewardPlayer()
    {
        for (int i = 0, length = rewards.Count; i < length; i++)
        {
            if (rewards[i] != null)
            {
                rewards[i].Reward();
            }
        }

    }

    [System.Serializable]
    public class QuestObjectif
    {
        public DataEnum.ObjectifTipe objectif;

        public string text;

        public int parameter;

        [HideInInspector]
        public bool objectifResult;
    }

}
