using System.Collections;
using System.Collections.Generic;
using System;

/// <summary>
/// Class that containt vehicle data in our system
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

}
