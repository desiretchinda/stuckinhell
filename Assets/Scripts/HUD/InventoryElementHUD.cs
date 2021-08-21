using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class InventoryElementHUD : MonoBehaviour
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

    public Button thisBtn;

    ///// <summary>
    ///// UI to display the price
    ///// </summary>
    //public TextMeshProUGUI txt_price;

    public void SetUp(DataItem data)
    {
        if (data == null)
            return;

        if(thisBtn)
        {
            thisBtn.GetComponentInChildren<TextMeshProUGUI>().text = "Use";
            thisBtn.onClick.RemoveAllListeners();
            thisBtn.onClick.AddListener(OnUse);
        }

        gameObject.SetActive(true);
        current = data;
        if (spRender)
            spRender.sprite = data.icon;

        if (txt_name)
            txt_name.text = data.name;

        //if (txt_price)
        //    txt_price.text = data.price + "$";
    }

    public void OnUse()
    {
        if(current != null)
        {
            current.Use();
            GameManager.SaveGame();
        }
    }
}
