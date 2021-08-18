using System.Collections;
using System.Collections.Generic;
using System;

/// <summary>
/// Class that contains all variable we want to save in this game
/// </summary>
[Serializable]
public class SaveData
{

    /// <summary>
    /// The unique refrence of player data in this game
    /// </summary>
    public DataPlayer player = new DataPlayer();

}
