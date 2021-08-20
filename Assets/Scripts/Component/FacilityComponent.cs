using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// The component that manages the player's interaction with a facility
/// </summary>
public class FacilityComponent : MonoBehaviour
{
    public int idFacility;

    public string nameFacility;

    public string welcomeText;

    public Sprite background;
       
    public AudioClip bgm;

    public List<PlayerAction> possibleAction = new List<PlayerAction>();

    public UnityEngine.UI.Button btnOpen;


    private void Start()
    {
        if (btnOpen)
        {
            btnOpen.GetComponentInChildren<TMPro.TextMeshProUGUI>().text = nameFacility;
            btnOpen.onClick.AddListener(OpenFacility);
        }
           
    }

    /// <summary>
    /// Fonction to open this facility
    /// </summary>
    public void OpenFacility()
    {
        FacilityHUD.Instance.DisplayFacility(idFacility, nameFacility, welcomeText, background, bgm, possibleAction);
    }

}
