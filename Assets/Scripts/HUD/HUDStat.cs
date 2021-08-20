using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HUDStat : MonoBehaviour
{

    public static HUDStat Instance;

    public TextMeshProUGUI txtMoney;

    public TextMeshProUGUI txtEnergy;

    public TextMeshProUGUI txtCurrentDay;

    public Button btnInventory;

    public Button btnQuestList;

    float prevMoney = -1;

    float prevEnegy = -1;

    float prevDay = -1;

    private void Awake()
    {
        Instance = this;

        if (btnInventory)
            btnInventory.onClick.AddListener(OpenInventory);


        if (btnQuestList)
            btnQuestList.onClick.AddListener(OpenQuestList);

    }

    private void Update()
    {
        RefreshHUD();
    }

    public void OpenQuestList()
    {
        QuestListhud.Instance.openHud();
    }

    public void OpenInventory()
    {
        InventoryHUD.Instance.OpenUI();
    }

    public void RefreshHUD()
    {
        if (txtEnergy && prevEnegy != GameManager.dataSave.player.energy)
            txtEnergy.text = "" + GameManager.dataSave.player.energy;

        if (txtMoney && prevMoney != GameManager.dataSave.player.TotalMoney())
            txtMoney.text = "" + GameManager.dataSave.player.TotalMoney() + "$";

        if (txtCurrentDay && prevDay != GameManager.dataSave.player.currentDay)
            txtCurrentDay.text = "" + GameManager.dataSave.player.currentDay;

    }
}
