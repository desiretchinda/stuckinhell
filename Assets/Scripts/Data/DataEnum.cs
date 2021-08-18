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
        OrderItem,
        Rob,
        Chat,
        Hack,
        Work,
        GetPromotion,
        Sleep,
        Dance,
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

    public enum ItemTipe
    {
        Consumable,
        Cloth,
        NonConsumable,
    }


}
