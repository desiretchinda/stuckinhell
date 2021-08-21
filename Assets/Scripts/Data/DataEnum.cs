using UnityEngine;

/// <summary>
/// the class that contains differents enum in our system.
/// </summary>
public static class DataEnum
{

    /// <summary>
    /// Differents possible directioni of à vehicle, Npc
    /// </summary>
    public enum PossibleDirection
    {
        Up,
        Down,
        Right,
        Left
    }

    /// <summary>
    /// Enum of differents state of the NPC
    /// </summary>
    public enum NPCState
    {
        Walking,
        Resting,
        Talking
    }

    /// <summary>
    /// Differents action player can do in this game
    /// </summary>
    public enum PlayerAction
    {
        GetJob,
        OrderItem,
        Rob,
        Chat,
        Hack,
        Work,
        GetPromotion,
        Sleep,
        Dance,
        borrow
    }

    /// <summary>
    /// Differents system action we can have in this game
    /// </summary>
    public enum SystemAction
    {
        UpdateEnergy,
        UpdateMoney,
        OfferItem,
        RemoveItem,
    }

    /// <summary>
    /// Differents type of item in this game
    /// </summary>
    public enum ItemTipe
    {
        NoClassified,
        Consumable,
        Cloth,
        NonConsumable,
    }

    /// <summary>
    /// Differents type of reward on this game
    /// </summary>
    public enum RewardTipe
    {
        AddMoney,
        AddEnergy,
        AddItem,
    }

    /// <summary>
    /// Differents type of objectifs in this game
    /// </summary>
    public enum ObjectifTipe
    {
        TalkToNumberNpc,
        BuyItem,
        UseItem,
        BuyNumberItem,
        UseNumberItem,
        TalkToNpc,
        GetNumberWork,
        GetWorkAt,
    }

    /// <summary>
    /// Condition
    /// </summary>
    public enum ConditionTipe
    {
        MoneyValue,
        EnergyValue,
        HasItem,
        DemonKill,
    }

}
