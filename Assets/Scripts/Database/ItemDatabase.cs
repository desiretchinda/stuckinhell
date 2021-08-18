using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

/// <summary>
/// Class to store vehicle database in our system
/// </summary>
public class ItemDatabase : ScriptableObject
{
    public List<DataItem> itemDatabase = new List<DataItem>();


#if UNITY_EDITOR

    [MenuItem("StuckOnHell DATABSE/create item database")]
    public static ItemDatabase Create()
    {

        ItemDatabase asset = ScriptableObject.CreateInstance<ItemDatabase>();

        AssetDatabase.CreateAsset(asset, "Assets/Resources/items_database.asset");
        Selection.activeObject = asset;
        AssetDatabase.SaveAssets();
        return asset;
    }

#endif

}
