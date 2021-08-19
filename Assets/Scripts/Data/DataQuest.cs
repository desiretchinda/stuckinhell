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
    /// x: condition type(equivalent in DataEnum.CondtionTipe)
    /// y,z,w: param of the condition
    /// </summary>
    public List<Vector4> appearCondition = new List<Vector4>();

    /// <summary>
    /// objectifs of this quest
    /// x: objectifs type(equivalent in DataEnum.ObjectifTipe)
    /// y,z,w: param of the objectifs
    /// </summary>
    public List<Vector4> objectifs = new List<Vector4>();

    /// <summary>
    /// objectifs of this quest
    /// x: reward type(equivalent in DataEnum.RewardTipe)
    /// y,z,w: param of the reward
    /// </summary>
    public List<Vector4> rewards = new List<Vector4>();

    /// <summary>
    /// Fonction to test condition if this quest can appear iingame
    /// </summary>
    /// <returns></returns>
    public bool ConditionOk()
    {
        for (int i = 0, length = appearCondition.Count; i < length; i++)
        {
            switch ((DataEnum.ConditionTipe)appearCondition[i].x)
            {
                case DataEnum.ConditionTipe.MoneyValue:
                    break;
                case DataEnum.ConditionTipe.EnergyValue:
                    break;
                case DataEnum.ConditionTipe.HasItem:
                    break;
                case DataEnum.ConditionTipe.DemonKill:
                    break;
            }
        }
        return true;
    }

    /// <summary>
    /// Fonctin to test if all ojectif are ok
    /// </summary>
    /// <returns></returns>
    public bool ObjectifOk()
    {
        for (int i = 0, length = objectifs.Count; i < length; i++)
        {
            switch ((DataEnum.ObjectifTipe)appearCondition[i].x)
            {
                case DataEnum.ObjectifTipe.TalkToNpc:
                    break;
                case DataEnum.ObjectifTipe.GetItem:
                    break;
                case DataEnum.ObjectifTipe.KillDemon:
                    break;
            }
        }

        return true;
    }

    /// <summary>
    /// Fonction to reward the player when completed this quest
    /// </summary>
    public void RewardPlayer()
    {
        for (int i = 0, length = rewards.Count; i < length; i++)
        {
            switch ((DataEnum.RewardTipe)rewards[i].x)
            {
                case DataEnum.RewardTipe.AddMoney:
                    break;
                case DataEnum.RewardTipe.AddEnergy:
                    break;
            }
        }

    }

}
