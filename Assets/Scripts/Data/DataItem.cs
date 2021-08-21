using System.Collections;
using System.Collections.Generic;
using System;

/// <summary>
/// Class that containt item data in our system
/// </summary>
[Serializable]
public class DataItem : BaseData
{

    /// <summary>
    /// The vehicle acceleration
    /// </summary>
    public int price;

    /// <summary>
    /// Definie if this item is collectable in the map
    /// </summary>
    public bool collectable;

    public DataEnum.ItemTipe tipe;

    [UnityEngine.Header("JUST FOR CLOTHS ITEM")]
    public UnityEngine.Sprite shirt;

    public UnityEngine.Sprite cap;

    public UnityEngine.Sprite pan;

    public UnityEngine.Sprite shoe;

    public List<PlayerReward> reward = new List<PlayerReward>();

    public void Use()
    {
        if(tipe == DataEnum.ItemTipe.Cloth)
        {
            GameManager.dataSave.player.currentCloth = id;
        }

        for (int i = 0, length = reward.Count; i < length; i++)
        {
            if(reward[i] != null)
            {
                reward[i].Reward();
            }
        }
        if(!GameManager.dataSave.player.itemUse.Contains(id))
        {
            GameManager.dataSave.player.itemUse.Add(id);
        }
    }

}
