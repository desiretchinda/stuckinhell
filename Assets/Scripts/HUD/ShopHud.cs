using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// HUD that display item for a shop
/// </summary>
public class ShopHud : MonoBehaviour
{

    public static ShopHud Instance;

    public List<ShopItemList> itemHud = new List<ShopItemList>();

    public UnityEngine.UI.Button closeBtn;

    public ShopData tmpShop;

    private void Awake()
    {
        Instance = this;
        if (closeBtn)
            closeBtn.onClick.AddListener(CloseShop);
        CloseShop();
    }

 

    /// <summary>
    /// Fonction to display a shop
    /// </summary>
    /// <param name="shopId"></param>
    public void OpenShop(int shopId)
    {

        tmpShop = GameManager.GetShop(shopId);
        if (tmpShop == null)
            return;

        PlayerComponent.Instance.preventMove = true;
        PlayerComponent.Instance.animator.SetBool("isMoving", false);
        for (int i = 0, length = itemHud.Count; i < length; i++)
        {
            if (itemHud[i])
                itemHud[i].gameObject.SetActive(false);
        }

        for (int i = 0, length = tmpShop.items.Count; i < length; i++)
        {
            if (itemHud.Count > i && itemHud[i])
            {
                itemHud[i].SetUp(GameManager.GetItem(tmpShop.items[i]));
            }
        }

        gameObject.SetActive(true);

    }

    public void CloseShop()
    {
        gameObject.SetActive(false);
    }
}
