using System.Collections;
using System.Collections.Generic;
using System;

/// <summary>
/// Class that contains NPC data in our database
/// </summary>
[Serializable]
public class DataNpc : BaseData
{

    /// <summary>
    /// Npc's speed
    /// </summary>
    public float movementSpeed = 2;


    /// <summary>
    /// The visual gameobjet of the npc driven buy this data
    /// </summary>
    public NpcComponent npcGameobject;
}
