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
    /// Differents action we can have in this game
    /// </summary>
    public enum PlayerAction
    {
        GetJob,
        OrderFood,
        RobFacility,
        Chat,
        Hack,
        Work,
        GetPromotion,
        Sleep
    }

    public enum ItemTipe
    {
        Consumable,
        NonConsumable,
    }


}
