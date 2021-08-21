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

    public bool occupied;

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

        occupied = true;
        if (btnAccept)
            btnAccept.gameObject.SetActive(true);

        if (txt_name)
            txt_name.text = tmpQuest.name;

        if (txt_description)
            txt_description.text = tmpQuest.description;

        //First hide objectifs
        for (int i = 0, length = txt_objectifs.Count; i < length; i++)
        {
            if (txt_objectifs[i])
                txt_objectifs[i].gameObject.SetActive(false);

            if (tmpQuest.objectifs.Count > i)
            {
                if (txt_objectifs[i])
                {
                    txt_objectifs[i].gameObject.SetActive(true);
                    if (tmpQuest.objectifs[i].objectifResult)
                        txt_objectifs[i].fontStyle = FontStyles.Strikethrough;
                    else
                        txt_objectifs[i].fontStyle = FontStyles.Normal;

                    txt_objectifs[i].text = tmpQuest.objectifs[i].text;
                }

            }

        }

        gameObject.SetActive(true);
        return true;
    }


    public bool DisplayQuest(DataQuest quest)
    {


        if (quest == null)
            return false;

        tmpQuest = quest;

        occupied = true;

        if (btnAccept)
            btnAccept.gameObject.SetActive(false);

        if (txt_name)
            txt_name.text = quest.name;

        if (txt_description)
            txt_description.text = quest.description;

        //First hide objectifs
        for (int i = 0, length = txt_objectifs.Count; i < length; i++)
        {
            if (txt_objectifs[i])
                txt_objectifs[i].gameObject.SetActive(false);

            if (tmpQuest.objectifs.Count > i)
            {
                if (txt_objectifs[i])
                {
                    txt_objectifs[i].gameObject.SetActive(true);
                    if (tmpQuest.objectifs[i].objectifResult)
                        txt_objectifs[i].fontStyle = FontStyles.Strikethrough;
                    else
                        txt_objectifs[i].fontStyle = FontStyles.Normal;

                    txt_objectifs[i].text = tmpQuest.objectifs[i].text;
                }

            }

        }

        gameObject.SetActive(true);
        return true;
    }

    public void OnBtnAccept()
    {
        SoundManager.Instance.PlaySfx(SoundManager.Instance.normalBtnSfx);
        if (tmpQuest != null)
        {
            GameManager.dataSave.player.activeQuest.Add(tmpQuest);
            GameManager.dataSave.player.energy--;

        }

        OnBtnLeave();
    }

    public void OnBtnLeave()
    {
        if (occupied)
            GameManager.SaveGame();
        occupied = false;
        gameObject.SetActive(false);
    }
}
