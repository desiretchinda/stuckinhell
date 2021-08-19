using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Component that manage all the game
/// </summary>
public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    /// <summary>
    /// Variable that contains the current state of the game data that need svae
    /// </summary>
    public static SaveData dataSave = new SaveData();


    /// <summary>
    /// Npc database cache
    /// </summary>
    public static List<DataNpc> npcCacheDatabase = new List<DataNpc>();


    /// <summary>
    /// Facilities databse cache
    /// </summary>
    public static List<DataFacility> facilityCacheDatabase = new List<DataFacility>();


    /// <summary>
    /// all dialogue database cache
    /// </summary>
    public static List<DialogData> dialogueCacheDatabase = new List<DialogData>();

    /// <summary>
    /// items databse cache
    /// </summary>
    public static List<DataItem> itemCacheDatabase = new List<DataItem>();

    /// <summary>
    /// quest databse cache
    /// </summary>
    public static List<DataQuest> questCacheDatabase = new List<DataQuest>();


    private void Awake()
    {
        Instance = this;
        DontDestroyOnLoad(gameObject);

        if (!LoadGame())
        {
            Newgame();
        }
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    /// <summary>
    /// Function to start game. always call each time we launch the game
    /// </summary>
    public static void StartGame()
    {
        if (!LoadGame())
        {
            Newgame();
        }
    }

    /// <summary>
    /// Function to make a newgame when the are no save available
    /// </summary>
    public static void Newgame()
    {
        dataSave = new SaveData();
        dataSave.player = GetPlayerData();
    }

    /// <summary>
    /// Function to load player save
    /// </summary>
    public static bool LoadGame()
    {
        return false;
    }

    /// <summary>
    /// Function to save the player game
    /// </summary>
    public static void SaveGame()
    {

    }

    /// <summary>
    /// Database function to get an NPC from the database
    /// </summary>
    /// <param name="id">NPC id</param>
    /// <returns></returns>
    public static DataNpc GetNpc(int id)
    {
        if (npcCacheDatabase == null || npcCacheDatabase.Count <= 0)
        {
            NpcDatabase database = Resources.Load<NpcDatabase>("npc_database");
            if (database == null)
                return null;

            npcCacheDatabase = database.npcDatabase;
        }


        if (npcCacheDatabase == null)
            return null;

        if (npcCacheDatabase.Count <= id)
            return null;



        return npcCacheDatabase.Find(x => (x.id == id));
    }


    /// <summary>
    /// Database function to get a facility from the database
    /// </summary>
    /// <param name="id">Facility ID</param>
    /// <returns></returns>
    public static DataFacility GetFacility(int id)
    {
        if (facilityCacheDatabase == null || facilityCacheDatabase.Count <= 0)
        {
            FacilityDatabase database = Resources.Load<FacilityDatabase>("facilities_database");
            if (database == null)
                return null;

            facilityCacheDatabase = database.facilityDatabase;
        }


        if (facilityCacheDatabase == null)
            return null;

        if (facilityCacheDatabase.Count <= id)
            return null;



        return facilityCacheDatabase.Find(x => (x.id == id));
    }

    /// <summary>
    /// Database function to get a item from the database
    /// </summary>
    /// <param name="id">Item ID</param>
    /// <returns></returns>
    public static DataItem GetItem(int id)
    {
        if (itemCacheDatabase == null || itemCacheDatabase.Count <= 0)
        {
            ItemDatabase database = Resources.Load<ItemDatabase>("items_database");
            if (database == null)
                return null;

            itemCacheDatabase = database.itemDatabase;
        }


        if (itemCacheDatabase == null)
            return null;

        if (itemCacheDatabase.Count <= id)
            return null;



        return itemCacheDatabase.Find(x => (x.id == id));
    }

    /// <summary>
    /// Database function to get a item from the database
    /// </summary>
    /// <param name="id">Item ID</param>
    /// <returns></returns>
    public static DataQuest GetQuest(int id)
    {
        if (questCacheDatabase == null || questCacheDatabase.Count <= 0)
        {
            QuestDatabase database = Resources.Load<QuestDatabase>("quests_database");
            if (database == null)
                return null;

            questCacheDatabase = database.questDatabase;
        }


        if (questCacheDatabase == null)
            return null;

        if (questCacheDatabase.Count <= id)
            return null;



        return questCacheDatabase.Find(x => (x.id == id));
    }

    /// <summary>
    /// Database function to get a item from the database
    /// </summary>
    /// <param name="id">Item ID</param>
    /// <returns></returns>
    public static List<DataItem> GetItems(bool collectable)
    {
        if (itemCacheDatabase == null || itemCacheDatabase.Count <= 0)
        {
            ItemDatabase database = Resources.Load<ItemDatabase>("items_database");
            if (database == null)
                return null;

            itemCacheDatabase = database.itemDatabase;
        }


        if (itemCacheDatabase == null)
            return null;

        return itemCacheDatabase.FindAll(x => (x.collectable == collectable));
    }


    /// <summary>
    /// Database function to get a dialogue from the database
    /// </summary>
    /// <param name="id">dialog ID</param>
    /// <returns></returns>
    public static DialogData GetDialog(int id)
    {
        if (dialogueCacheDatabase == null || dialogueCacheDatabase.Count <= 0)
        {
            DialogDatabase database = Resources.Load<DialogDatabase>("dialogue_database");
            if (database == null)
                return null;

            dialogueCacheDatabase = database.dialogDatabase;
        }


        if (dialogueCacheDatabase == null)
            return null;

        if (dialogueCacheDatabase.Count <= id)
            return null;



        return dialogueCacheDatabase.Find(x => (x.id == id));
    }

    /// <summary>
    /// Database function to get a dialogue from the database
    /// </summary>
    /// <param name="id">dialog ID</param>
    /// <returns></returns>
    public static DialogData GetRandomDialog()
    {
        if (dialogueCacheDatabase == null || dialogueCacheDatabase.Count <= 0)
        {
            DialogDatabase database = Resources.Load<DialogDatabase>("dialogue_database");
            if (database == null)
                return null;

            dialogueCacheDatabase = database.dialogDatabase;
        }

        int id = UnityEngine.Random.Range(0, dialogueCacheDatabase.Count);
        if (dialogueCacheDatabase == null)
            return null;

        if (dialogueCacheDatabase.Count <= id)
            return null;



        return dialogueCacheDatabase.Find(x => (x.id == id));
    }

    /// <summary>
    /// Database function to get the player data from the database
    /// </summary>
    /// <returns></returns>
    private static DataPlayer GetPlayerData()
    {

        PlayerDatabase database = Resources.Load<PlayerDatabase>("base_player");
        if (database == null)
            return null;


        return database.dataPlayer;

    }

}
