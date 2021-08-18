using System.Collections;
using System.Collections.Generic;
using System;

/// <summary>
/// The class that contains the basic data of any object in our database
/// </summary>
[Serializable]
public class BaseData
{
    /// <summary>
    /// The unique iD of the Data
    /// </summary>
    public int id;

    /// <summary>
    /// The data name
    /// </summary>
    public string name;

    /// <summary>
    /// Data icon
    /// </summary>
    public UnityEngine.Sprite icon;

}
