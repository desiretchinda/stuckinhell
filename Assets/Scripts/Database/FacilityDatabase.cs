using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

/// <summary>
/// Class to store facility database in our system
/// </summary>
public class FacilityDatabase : ScriptableObject
{

    public List<DataFacility> facilityDatabase = new List<DataFacility>();


#if UNITY_EDITOR

    [MenuItem("StuckOnHell DATABSE/create facilities database")]
    public static void Create()
    {

        FacilityDatabase asset = ScriptableObject.CreateInstance<FacilityDatabase>();

        AssetDatabase.CreateAsset(asset, "Assets/Resources/facilities_database.asset");
        Selection.activeObject = asset;
        AssetDatabase.SaveAssets();
    }
#endif

}
