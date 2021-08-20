using System.Collections;
using System.Collections.Generic;
using System;

/// <summary>
/// Class that containt shop data in our system
/// </summary>
[Serializable]
public class ShopData : BaseData
{

    /// <summary>
    /// Definie if this shop is a clothes shop
    /// </summary>
    public bool clothesShop;

    public List<int> items = new List<int>();

}
