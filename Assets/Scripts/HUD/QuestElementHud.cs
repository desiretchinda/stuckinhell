using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class QuestElementHud : MonoBehaviour
{
    [HideInInspector]
    public DataQuest current;

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
    ///// UI to display the quest
    ///// </summary>
    //public TextMeshProUGUI txt_price;

    public void SetUp(DataQuest data)
    {
        if (data == null)
            return;

        gameObject.SetActive(true);
        current = data;
        if (spRender)
            spRender.sprite = data.icon;

        if (txt_name)
            txt_name.text = data.name;

        gameObject.SetActive(true);

    }
}
