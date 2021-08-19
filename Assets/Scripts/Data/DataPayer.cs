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
    /// Player's health
    /// </summary>
    public float health;

    /// <summary>
    /// Player's health
    /// </summary>
    public float energy;

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

    public float TotalMoney()
    {
        return earnMoney + bankMoney;
    }

    public bool RemoveMoney(float amount)
    {
        if (earnMoney >= amount)
        {
            earnMoney -= amount;
            return true;
        }

        if (bankMoney >= amount)
        {
            bankMoney -= amount;
            return true;
        }

        if ((earnMoney + bankMoney) >= amount)
        {
            amount -= earnMoney;
            earnMoney = 0;
            bankMoney -= amount;
        }

        return false;
    }

}
