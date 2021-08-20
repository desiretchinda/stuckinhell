using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestListhud : MonoBehaviour
{
    public static QuestListhud Instance;

    public List<QuestElementHud> itemHud = new List<QuestElementHud>();

    public Button closeBtn;

    private void Awake()
    {
        Instance = this;
        Close();
    }

    private void Start()
    {
        if (closeBtn)
            closeBtn.onClick.AddListener(Close);
    }

    public void openHud()
    {
        for (int i = 0, length = itemHud.Count; i < length; i++)
        {
            if (itemHud[i])
                itemHud[i].gameObject.gameObject.SetActive(false);

            if(GameManager.dataSave.player.activeQuest.Count > i)
            {
                itemHud[i].SetUp(GameManager.GetQuest(GameManager.dataSave.player.activeQuest[i]));
            }
        }

        gameObject.SetActive(true);
    }

    public void Close()
    {
        gameObject.SetActive(false);
    }
}
