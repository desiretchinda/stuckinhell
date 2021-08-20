using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

/// <summary>
/// Class to store shop database in our system
/// </summary>
public class ShopDatabase : ScriptableObject
{
    public List<ShopData> shopDatabase = new List<ShopData>();


#if UNITY_EDITOR

    [MenuItem("StuckOnHell DATABSE/create shop database")]
    public static ShopDatabase Create()
    {

        ShopDatabase asset = ScriptableObject.CreateInstance<ShopDatabase>();

        AssetDatabase.CreateAsset(asset, "Assets/Resources/shop_database.asset");
        Selection.activeObject = asset;
        AssetDatabase.SaveAssets();
        return asset;
    }

#endif

}
