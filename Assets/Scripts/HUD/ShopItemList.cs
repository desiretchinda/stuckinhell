using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ShopItemList : MonoBehaviour
{
    [HideInInspector]
    public DataItem current;

    /// <summary>
    /// UI to display the icon
    /// </summary>
    public Image spRender;

    /// <summary>
    /// UI to display the name
    /// </summary>
    public TextMeshProUGUI txt_name;

    public Button btnBuy;


    public Button btnTry;

    public DataItem tmpData;

    /// <summary>
    /// UI to display the price
    /// </summary>
    public TextMeshProUGUI txt_price;

    public void SetUp(DataItem data)
    {
        if (data == null)
            return;

        tmpData = data;

        if (btnTry)
            if (tmpData.tipe == DataEnum.ItemTipe.Cloth)
            {
                btnTry.gameObject.SetActive(true);
            }
            else
            {
                btnTry.gameObject.SetActive(false);
            }

        if (btnBuy)
            btnBuy.onClick.RemoveAllListeners();

        if (btnTry)
            btnTry.onClick.RemoveAllListeners();


        if (btnBuy)
        {
            btnBuy.onClick.AddListener(onBtnBuy);
            if (GameManager.dataSave.player.TotalMoney() >= data.price)
            {
                btnBuy.interactable = true;
            }
            else
            {
                btnBuy.interactable = false;
            }
        }


        if (btnTry)
            btnTry.onClick.AddListener(onBtnTry);

        gameObject.SetActive(true);
        current = data;
        if (spRender)
            spRender.sprite = data.icon;

        if (txt_name)
            txt_name.text = data.name;

        //if (txt_price)
        //    txt_price.text = data.price + "$";
    }


    /// <summary>
    /// 
    /// </summary>
    public void onBtnTry()
    {
        SoundManager.Instance.PlaySfx(SoundManager.Instance.normalBtnSfx);
        GameManager.dataSave.player.energy--;
        if (tmpData.tipe == DataEnum.ItemTipe.Cloth && ShopHud.Instance.shopRobotBody)
        {
            ShopHud.Instance.shopRobotBody.sprite = tmpData.shirt;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public void onBtnBuy()
    {
        SoundManager.Instance.PlaySfx(SoundManager.Instance.normalBtnSfx);
        if (tmpData == null)
            return;



        if (GameManager.dataSave.player.RemoveMoney(tmpData.price))
        {

            if (tmpData.tipe == DataEnum.ItemTipe.Consumable)
            {
                tmpData.Use();
            }
            else
            {
                GameManager.dataSave.player.inventory.Add(tmpData);
            }


            if (!GameManager.dataSave.player.itemBuy.Contains(tmpData.id))
            {
                GameManager.dataSave.player.itemBuy.Add(tmpData.id);
            }

            GameManager.dataSave.player.energy--;
        }
        GameManager.SaveGame();
    }
}
