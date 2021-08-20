using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class QuestHud : MonoBehaviour
{

    public static QuestHud Instance;

    /// <summary>
    /// Bouton to leave the dialog
    /// </summary>
    public Button btnLeave;

    /// <summary>
    /// Boutton to accept the quest
    /// </summary>
    public Button btnAccept;

    /// <summary>
    /// UI to display the quest name
    /// </summary>
    public TextMeshProUGUI txt_name;

    /// <summary>
    /// UI to display the quest description
    /// </summary>
    public TextMeshProUGUI txt_description;

    /// <summary>
    /// Ui to display quest objectifs
    /// </summary>
    public List<TextMeshProUGUI> txt_objectifs = new List<TextMeshProUGUI>();

    /// <summary>
    /// Ui to display quest reward
    /// </summary>
    public List<TextMeshProUGUI> txt_reward = new List<TextMeshProUGUI>();

    private DataQuest tmpQuest;

    private void Awake()
    {
        Instance = this;
        OnBtnLeave();
    }

    // Start is called before the first frame update
    void Start()
    {
        if (btnAccept)
            btnAccept.onClick.AddListener(OnBtnAccept);

        if (btnLeave)
            btnLeave.onClick.AddListener(OnBtnLeave);

    }


    public bool DisplayQuest(int questID)
    {
        tmpQuest = GameManager.GetQuest(questID);

        if (tmpQuest == null)
            return false;

        if (txt_name)
            txt_name.text = tmpQuest.name;

        if (txt_description)
            txt_description.text = tmpQuest.description;

        //First hide objectifs
        for (int i = 0, length = txt_objectifs.Count; i < length; i++)
        {
            if (txt_objectifs[i])
                txt_objectifs[i].gameObject.SetActive(false);

            if(tmpQuest.objectifs.Count > i)
            {
                switch ((DataEnum.ObjectifTipe)tmpQuest.objectifs[i].x)
                {
                    case DataEnum.ObjectifTipe.TalkToNpc:
                        if (txt_objectifs[i])
                            txt_objectifs[i].gameObject.SetActive(true);
                        txt_objectifs[i].text = "Talk to NPC";
                        break;
                    case DataEnum.ObjectifTipe.GetItem:
                        if (txt_objectifs[i])
                            txt_objectifs[i].gameObject.SetActive(true);
                        txt_objectifs[i].text = "Get Item";
                        break;
                    case DataEnum.ObjectifTipe.KillDemon:
                        if (txt_objectifs[i])
                            txt_objectifs[i].gameObject.SetActive(true);
                        txt_objectifs[i].text = "Kill demon";
                        break;
                }
            }

        }

        gameObject.SetActive(true);
        return true;
    }

    public void OnBtnAccept()
    {
        if (tmpQuest != null)
        {
            GameManager.dataSave.player.activeQuest.Add(tmpQuest.id);
        }
            
        OnBtnLeave();
    }

    public void OnBtnLeave()
    {
        gameObject.SetActive(false);
    }
}
