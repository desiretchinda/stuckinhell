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


    private void Start()
    {

    }

    /// <summary>
    /// Fonction to open this facility
    /// </summary>
    public void OpenFacility()
    {
        FacilityHUD.Instance.DisplayFacility(idFacility, nameFacility, welcomeText, background, bgm, possibleAction);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            PlayerComponent.Instance.currentFrontFacility = this;
            if (GameManager.Instance.btnEnter)
                GameManager.Instance.btnEnter.gameObject.SetActive(true);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            PlayerComponent.Instance.currentFrontFacility = null;
            if (GameManager.Instance.btnEnter)
                GameManager.Instance.btnEnter.gameObject.SetActive(false);
        }
    }

}
