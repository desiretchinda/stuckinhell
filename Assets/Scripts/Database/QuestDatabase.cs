using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

/// <summary>
/// Class to store quest database in our system
/// </summary>
public class QuestDatabase : ScriptableObject
{
    public List<DataQuest> questDatabase = new List<DataQuest>();


#if UNITY_EDITOR

    [MenuItem("StuckOnHell DATABSE/create quest database")]
    public static void Create()
    {

        QuestDatabase asset = ScriptableObject.CreateInstance<QuestDatabase>();

        AssetDatabase.CreateAsset(asset, "Assets/Resources/quests_database.asset");
        Selection.activeObject = asset;
        AssetDatabase.SaveAssets();
    }

#endif

}
