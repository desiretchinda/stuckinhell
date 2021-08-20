using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

/// <summary>
/// Class to store dialog database in our system
/// </summary>
public class DialogDatabase : ScriptableObject
{
    public List<DialogData> dialogDatabase = new List<DialogData>();


#if UNITY_EDITOR

    [MenuItem("StuckOnHell DATABSE/create dialogue database")]
    public static void Create()
    {

        DialogDatabase asset = ScriptableObject.CreateInstance<DialogDatabase>();

        AssetDatabase.CreateAsset(asset, "Assets/Resources/dialogue_database.asset");
        Selection.activeObject = asset;
        AssetDatabase.SaveAssets();
    }

    private void OnEnable()
    {
        for (int i = 0, length = dialogDatabase.Count; i < length; i++)
        {
            dialogDatabase[i].id = i;
        }

        EditorUtility.SetDirty(this);
        //AssetDatabase.SaveAssets();
    }
#endif

}
