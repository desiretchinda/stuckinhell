using UnityEngine;
using System.Collections;

[System.Serializable]
public class PlayerReward 
{
    public DataEnum.RewardTipe rewardTipe;

    public float parameter;

    public bool remove;

    public void Reward()
    {
        switch (rewardTipe)
        {
            case DataEnum.RewardTipe.AddMoney:
                if(remove)
                {
                    GameManager.dataSave.player.RemoveMoney(parameter);
                }else
                {
                    GameManager.dataSave.player.AddMoney(parameter);
                }
                break;
            case DataEnum.RewardTipe.AddEnergy:
                if (remove)
                {
                    GameManager.dataSave.player.RemoveEnergy(parameter);
                }
                else
                {
                    GameManager.dataSave.player.AddEnergy(parameter);
                }
                break;
            case DataEnum.RewardTipe.AddItem:
                if (remove)
                {
                    GameManager.dataSave.player.RemoveItem((int)parameter);
                }
                else
                {
                    GameManager.dataSave.player.AddItem((int)parameter);
                }
                break;
        }
    }
}
