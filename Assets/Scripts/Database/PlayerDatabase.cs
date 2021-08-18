using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

/// <summary>
/// Class to store player unique data in our system
/// </summary>
public class PlayerDatabase : ScriptableObject
{
    public DataPlayer dataPlayer = new DataPlayer();

#if UNITY_EDITOR

    [MenuItem("StuckOnHell DATABSE/create base player")]
    public static void Create()
    {

        PlayerDatabase asset = ScriptableObject.CreateInstance<PlayerDatabase>();

        AssetDatabase.CreateAsset(asset, "Assets/Resources/base_player.asset");
        Selection.activeObject = asset;
        AssetDatabase.SaveAssets();
    }
#endif
}
