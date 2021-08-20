using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryHUD : MonoBehaviour
{
    public static InventoryHUD Instance;

    public List<InventoryElementHUD> itemHud = new List<InventoryElementHUD>();

    public Button closeBtn;

    private void Awake()
    {
        Instance = this;
        if (closeBtn)
            closeBtn.onClick.AddListener(CloseUI);
        CloseUI();

    }

    public void OpenUI()
    {
        PlayerComponent.Instance.preventMove = true;
        PlayerComponent.Instance.animator.SetBool("isMoving", false);
        for (int i = 0, length = itemHud.Count; i < length; i++)
        {
            if (itemHud[i])
                itemHud[i].gameObject.SetActive(false);
        }

        for (int i = 0, length = GameManager.dataSave.player.inventory.Count; i < length; i++)
        {
            if (itemHud.Count > i && GameManager.dataSave.player.inventory[i] != null && itemHud[i])
            {
                itemHud[i].SetUp(GameManager.dataSave.player.inventory[i]);
            }
        }

        gameObject.SetActive(true);
    }

    public void CloseUI()
    {
        if (PlayerComponent.Instance)
            PlayerComponent.Instance.preventMove = false;
        gameObject.SetActive(false);
    }
}
