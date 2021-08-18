using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

/// <summary>
/// Class to store npc database in our system
/// </summary>
public class NpcDatabase : ScriptableObject
{
    public List<DataNpc> npcDatabase = new List<DataNpc>();


#if UNITY_EDITOR

    [MenuItem("StuckOnHell DATABSE/create NPC database")]
    public static void Create()
    {

        NpcDatabase asset = ScriptableObject.CreateInstance<NpcDatabase>();

        AssetDatabase.CreateAsset(asset, "Assets/Resources/npc_database.asset");
        Selection.activeObject = asset;
        AssetDatabase.SaveAssets();
    }
#endif

}
