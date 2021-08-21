using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

/// <summary>
/// The dialogue UI classe
/// </summary>
public class DialogHUD : MonoBehaviour
{

    public TextMeshProUGUI txtName;

    public TextMeshProUGUI txtDialogText;

    public Image imgface;

    public List<TextMeshProUGUI> txtChoices = new List<TextMeshProUGUI>();

    public Button btnLeave;


    public static DialogHUD Instance;

    private void Awake()
    {
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {

        if (btnLeave)
            btnLeave.onClick.AddListener(LeaveDialog);
        HideChoices();
        if (!GameManager.dataSave.alreadyPlay)
        {
            DialogHUD.Instance.DisplayDialog(GameManager.GetDialog(30, true), null);
        }
        else
            gameObject.SetActive(false);
    }

    /// <summary>
    /// Function that display a dialog on the HUD dialog
    /// </summary>
    /// <param name="data"></param>
    public void DisplayDialog(DialogData data, Sprite face)
    {
        if (data == null)
            return;

        HideChoices();

        if (txtName)
            txtName.text = data.name;

        if (imgface && face)
            imgface.sprite = face;

        if (txtDialogText)
            txtDialogText.text = data.dialogText;

        PlayerComponent.Instance.preventMove = true;
        DisplayChoices(data);
        gameObject.SetActive(true);
    }

    /// <summary>
    /// Use yhis function to hide choices buton on the dialog box
    /// </summary>
    public void HideChoices()
    {
        if (txtChoices == null)
            return;

        for (int i = 0, length = txtChoices.Count; i < length; i++)
        {
            if (txtChoices[i])
            {
                txtChoices[i].transform.parent.gameObject.SetActive(false);
            }
        }
    }

    /// <summary>
    /// Use this function to display a given dialog choices
    /// </summary>
    /// <param name="data">Dialog choices to display</param>
    public void DisplayChoices(DialogData data)
    {
        if (txtChoices == null || data == null)
            return;

        for (int i = 0, length = data.choices.Count; i < length; i++)
        {
            if (txtChoices.Count > i && txtChoices[i] && data.choices[i] != null)
            {
                Button btn = txtChoices[i].transform.parent.GetComponent<Button>();
                int index = i;
                if (btn)
                {
                    btn.onClick.RemoveAllListeners();
                    btn.onClick.AddListener(() => { ExecuteChoice(data.choices[index]); });
                }

                txtChoices[index].transform.parent.gameObject.SetActive(true);
                txtChoices[index].text = data.choices[index].choiceText;
            }
        }
    }

    /// <summary>
    /// Function to execute à choice
    /// </summary>
    /// <param name="choice"></param>
    public void ExecuteChoice(ChoiceData choice)
    {
        if (choice == null)
            return;

        if (choice.nextDialogId > 0)
            DisplayDialog(GameManager.GetDialog(choice.nextDialogId, ((choice.nextDialogId == 31 | choice.nextDialogId == 32) ? true : false)), null);
        else
            LeaveDialog();
    }

    /// <summary>
    /// Function to close thsi dialog box
    /// </summary>
    public void LeaveDialog()
    {
        PlayerComponent.Instance.preventMove = false;
        gameObject.SetActive(false);
    }

}
