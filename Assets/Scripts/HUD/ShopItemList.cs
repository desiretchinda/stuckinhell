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
            btnBuy.onClick.AddListener(onBtnBuy);

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

    }

    /// <summary>
    /// 
    /// </summary>
    public void onBtnBuy()
    {
        if (tmpData == null)
            return;


        if (GameManager.dataSave.player.RemoveMoney(tmpData.price))
        {
            GameManager.dataSave.player.inventory.Add(tmpData);
        }

    }
}
