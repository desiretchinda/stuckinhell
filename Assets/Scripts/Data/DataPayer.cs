using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

/// <summary>
/// Class that contains player data.
/// </summary>
[Serializable]
public class DataPlayer : BaseData
{

    /// <summary>
    /// Player's level
    /// </summary>
    public float level;

    /// <summary>
    /// Player money in bank
    /// </summary>
    public float bankMoney;

    /// <summary>
    /// Player's Earn money
    /// </summary>
    public float earnMoney;

    /// <summary>
    /// The current day ingame
    /// </summary>
    public int currentDay = 1;

    /// <summary>
    /// Player's inventory
    /// </summary>
    public List<DataItem> inventory = new List<DataItem>();


    /// <summary>
    /// Player's track of use item
    /// </summary>
    public List<int> itemUse = new List<int>();

    /// <summary>
    /// Player's track of buy item
    /// </summary>
    public List<int> itemBuy = new List<int>();


    /// <summary>
    /// Player accepted quest
    /// </summary>
    public List<DataQuest> activeQuest = new List<DataQuest>();

    /// <summary>
    /// Player completed quest
    /// </summary>
    public List<int> completedQuest = new List<int>();
    
    /// <summary>
    /// Player differents job places
    /// </summary>
    public List<int> playerJobs = new List<int>();

    /// <summary>
    /// differents npc talk to
    /// </summary>
    public List<int> npcTalkTo = new List<int>();

    public int currentCloth = -1;

    public int energy;

    public float TotalMoney()
    {
        return earnMoney + bankMoney;
    }

    public bool CanAskJob(int idFacility)
    {

        return !playerJobs.Contains(idFacility);
    }

    public bool CanWork(int idFacility)
    {
        return playerJobs.Contains(idFacility);
    }

    public void AddMoney(float amount)
    {
        earnMoney -= amount;

        if (earnMoney < 0)
            earnMoney = 0;

        GameManager.SaveGame();
    }

    public void RemoveEnergy(float value)
    {
        energy -= (int)value;

        if (energy < 0)
            energy = 0;
    }

    public void AddEnergy(float value)
    {
        energy += (int)value;

    }


    public void RemoveItem(int id)
    {
        int index = inventory.FindIndex(it => (it.id == id));

        if (index >= 0 && inventory.Count > index)
            inventory.RemoveAt(index);

        GameManager.SaveGame();
    }

    public void AddItem(int id)
    {
        AddItem(GameManager.GetItem(id));
    }

    public void AddItem(DataItem it)
    {
        if (it != null)
            inventory.Add(it);

    }

    public bool RemoveMoney(float amount)
    {

        if (earnMoney >= amount)
        {
            earnMoney -= amount;
            GameManager.SaveGame();
            return true;
        }

        if (bankMoney >= amount)
        {
            bankMoney -= amount;
            GameManager.SaveGame();
            return true;
        }

        if ((earnMoney + bankMoney) >= amount)
        {
            amount -= earnMoney;
            earnMoney = 0;
            bankMoney -= amount;
        }
        GameManager.SaveGame();
        return false;
    }

}
