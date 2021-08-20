using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

/// <summary>
/// The dialogue UI classe
/// </summary>
public class FacilityHUD : MonoBehaviour
{

    public TextMeshProUGUI txtName;

    public TextMeshProUGUI txtWelcome;

    public Image imgBG;

    public List<TextMeshProUGUI> txtPlayerActions = new List<TextMeshProUGUI>();

    public Button btnLeave;


    public static FacilityHUD Instance;

    private void Awake()
    {
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {

        if (btnLeave)
            btnLeave.onClick.AddListener(LeaveFacility);
        HideActions();
        gameObject.SetActive(false);
    }

    /// <summary>
    /// Function that display a facility
    /// </summary>
    /// <param name="data"></param>
    public void DisplayFacility(int id, string name, string welcomText, Sprite bg, AudioClip bgm, List<PlayerAction> possibleAction)
    {

        PlayerComponent.Instance.animator.SetBool("isMoving", false);

        HideActions();

        if (txtName)
            txtName.text = name;

        if (imgBG && bg)
            imgBG.sprite = bg;

        if (txtWelcome)
            txtWelcome.text = welcomText;

        PlayerComponent.Instance.preventMove = true;
        DisplayActions(id, possibleAction);
        gameObject.SetActive(true);
    }

    /// <summary>
    /// Use yhis function to hide choices buton on the dialog box
    /// </summary>
    public void HideActions()
    {
        if (txtPlayerActions == null)
            return;

        for (int i = 0, length = txtPlayerActions.Count; i < length; i++)
        {
            if (txtPlayerActions[i])
            {
                txtPlayerActions[i].transform.parent.gameObject.SetActive(false);
            }
        }
    }

    /// <summary>
    /// Use this function to display a given dialog choices
    /// </summary>
    /// <param name="id">facility</param>
    public void DisplayActions(int id, List<PlayerAction> possibleAction)
    {
        if (txtPlayerActions == null || possibleAction == null)
            return;

        //The index of the current txtPlayerActions where to display action
        int indexgoList = 0;

        for (int i = 0, length = possibleAction.Count; i < length; i++)
        {

            if (txtPlayerActions.Count > indexgoList && txtPlayerActions[indexgoList] && possibleAction[i] != null)
            {

                Button btn = txtPlayerActions[indexgoList].transform.parent.GetComponent<Button>();
                int index = i;
                if (btn)
                {
                    btn.onClick.RemoveAllListeners();
                }


                if (possibleAction[index].availableAfterEveryThisDay > 0 && GameManager.dataSave.player.currentDay % possibleAction[index].availableAfterEveryThisDay != 0)
                    continue;

                //if (!GameManager.dataSave.player.CanActionThis(possibleAction[index], id, index))
                //    continue;

                if (possibleAction[i].action == DataEnum.PlayerAction.GetJob && !GameManager.dataSave.player.CanAskJob(id))
                    continue;

                if (possibleAction[i].action == DataEnum.PlayerAction.Work && !GameManager.dataSave.player.CanWork(id))
                    continue;


                if (btn)
                {
                    btn.onClick.AddListener(() => { ExecuteChoice(possibleAction, id, index); });
                }

                txtPlayerActions[indexgoList].transform.parent.gameObject.SetActive(true);
                txtPlayerActions[indexgoList].text = possibleAction[index].ToString();
                indexgoList++;
            }
        }
    }

    /// <summary>
    /// Function to execute à choice
    /// </summary>
    /// <param name="action"></param>
    public void ExecuteChoice(List<PlayerAction> action, int idFacility, int actionIndex)
    {

        if (action == null)
            return;

        Debug
        switch (action[actionIndex].action)
        {
            case DataEnum.PlayerAction.GetJob:

                if (GameManager.dataSave.player.currentDayAction <= 0)
                    return;

                if (GameManager.dataSave.player.CanAskJob(idFacility))
                {
                    GameManager.dataSave.player.playerJobs.Add(idFacility);
                }

                break;
            case DataEnum.PlayerAction.OrderItem:

                ShopHud.Instance.OpenShop(action[actionIndex].parameter);
                break;
            case DataEnum.PlayerAction.Rob:
                if (GameManager.dataSave.player.currentDayAction <= 0)
                    return;

                GameManager.dataSave.player.earnMoney += action[actionIndex].parameter;
                GameManager.dataSave.player.currentDayAction--;
                break;
            case DataEnum.PlayerAction.Chat:
                DialogData dialog = GameManager.GetRandomDialog();

                if (dialog != null)
                {
                    if (txtName)
                        txtName.text = dialog.name;

                    if (txtWelcome)
                        txtWelcome.text = dialog.dialogText;
                }
                break;
            case DataEnum.PlayerAction.Hack:
                if (GameManager.dataSave.player.currentDayAction <= 0)
                    return;

                GameManager.dataSave.player.earnMoney += action[actionIndex].parameter;
                GameManager.dataSave.player.currentDayAction--;

                break;
            case DataEnum.PlayerAction.Work:
                if (GameManager.dataSave.player.currentDayAction <= 0)
                    return;

                if(GameManager.dataSave.player.CanWork(idFacility))
                {
                    GameManager.dataSave.player.earnMoney += action[actionIndex].parameter;
                    GameManager.dataSave.player.currentDayAction--;
                }

                break;
            case DataEnum.PlayerAction.GetPromotion:
                if (GameManager.dataSave.player.currentDayAction <= 0)
                    return;
                break;
            case DataEnum.PlayerAction.Sleep:
               
                GameManager.NexDay();
                break;
            default:
                break;
        }

        HideActions();
        DisplayActions(idFacility, action);
    }


    /// <summary>
    /// Function to close thsi dialog box
    /// </summary>
    public void LeaveFacility()
    {
        PlayerComponent.Instance.preventMove = false;
        gameObject.SetActive(false);
    }

}
