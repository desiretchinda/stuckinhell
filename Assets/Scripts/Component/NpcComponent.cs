using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// The component that manages the player's interaction with an NPC
/// </summary>
public class NpcComponent : CharacterComponent
{
    /// <summary>
    /// NPC possible direction on the map
    /// </summary>
    public List<DataEnum.PossibleDirection> possibleDirection = new List<DataEnum.PossibleDirection>();

    /// <summary>
    /// Variable that define how many time the NPC can rest after walking
    /// </summary>
    public float restTime = -1;

    /// <summary>
    /// Variable that define how many time this NPC can walk
    /// </summary>
    public float walkTime = -1;

    /// <summary>
    /// The NPC face in the dialog box
    /// </summary>
    public Sprite dialogFace;

    /// <summary>
    /// Index of the npc next direction
    /// </summary>
    private int nextDirectionIndex;

    private DataEnum.PossibleDirection lastDirection = new DataEnum.PossibleDirection();

    /// <summary>
    /// Counter for restime
    /// </summary>
    private float counterRestTime;

    /// <summary>
    /// Counter for walktime
    /// </summary>
    private float counterWalkTime;

    /// <summary>
    /// Npc state on the map
    /// </summary>
    private DataEnum.NPCState npcState = DataEnum.NPCState.Walking;

    List<DataEnum.PossibleDirection> newPossibleDirection = new List<DataEnum.PossibleDirection>();

    /// <summary>
    /// Quest that this npc can give to the player
    /// </summary>
    public List<int> idQuests = new List<int>();

    private DialogData npcDialog = null;
    new void Awake()
    {
        base.Awake();
    }

    new void Start()
    {
        base.Start();

        if (restTime < 0)
            restTime = Random.Range(1, 5);

        if (walkTime < 0)
            walkTime = Random.Range(1, 5);

        counterRestTime = restTime;
        counterWalkTime = walkTime;
        movementSpeed = Random.Range(1f, 3f);

        ChangeDirection();
    }

    // Update is called once per frame
    new void Update()
    {
        //State when NPC are walking
        if (npcState == DataEnum.NPCState.Walking)
        {
            counterWalkTime -= (float)Time.deltaTime;
            if (counterWalkTime <= 0)
            {
                if (walkTime < 0)
                    walkTime = Random.Range(1, 5);

                counterWalkTime = walkTime;
                npcState = DataEnum.NPCState.Resting;
            }
        }

        //State when NPC are resting
        if (npcState == DataEnum.NPCState.Resting)
        {
            counterRestTime -= (float)Time.deltaTime;
            if (counterRestTime <= 0)
            {
                if (restTime < 0)
                    restTime = Random.Range(1, 5);

                counterRestTime = restTime;
                ChangeDirection();
            }
        }


        base.Update();
    }

    /// <summary>
    /// Function to change the direction of a vehicle when it arrives at a junction
    /// </summary>
    private void ChangeDirection(bool preventLastDirection = false)
    {
        if (possibleDirection == null)
            return;

        if (possibleDirection.Count <= 0)
            return;


        List<DataEnum.PossibleDirection> newPossibleDirection = new List<DataEnum.PossibleDirection>();

        for (int i = 0, length = possibleDirection.Count; i < length; i++)
        {
            if (preventLastDirection && possibleDirection[i] == lastDirection)
                continue;
            newPossibleDirection.Add(possibleDirection[i]);
        }


        nextDirectionIndex = Random.Range(0, newPossibleDirection.Count);

        switch (newPossibleDirection[nextDirectionIndex])
        {
            case DataEnum.PossibleDirection.Up:
                movement = Vector3.up;
                break;
            case DataEnum.PossibleDirection.Down:
                movement = Vector3.down;
                break;
            case DataEnum.PossibleDirection.Right:
                movement = Vector3.right;
                break;
            case DataEnum.PossibleDirection.Left:
                movement = Vector3.left;
                break;
            default:
                break;
        }

        npcState = DataEnum.NPCState.Walking;
        lastDirection = newPossibleDirection[nextDirectionIndex];
    }

    /// <summary>
    /// Display a dialog on this NPC head
    /// </summary>
    public void DisplayDialog()
    {
        DialogHUD.Instance.DisplayDialog(npcDialog, dialogFace);
    }


    /// <summary>
    /// Display a dialog on this NPC head
    /// </summary>
    public bool DisplayQuest()
    {
        for (int i = 0, length = idQuests.Count; i < length; i++)
        {
            if (!GameManager.dataSave.player.activeQuest.Contains(idQuests[i]) && !GameManager.dataSave.player.completedQuest.Contains(idQuests[i]))
            {
                return QuestHud.Instance.DisplayQuest(idQuests[i]);
            }
            
        }
        return false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player") && !PlayerComponent.Instance.currentTalkingNpc)
        {
            npcDialog = GameManager.GetRandomDialog();
            rigbody.mass = 1000;
            PlayerComponent.Instance.currentTalkingNpc = this;
            if (GameManager.Instance.btntalk)
                GameManager.Instance.btntalk.gameObject.SetActive(true);
            FlipToDirection(collision.collider.transform.position);
            //PlayerComponent.Instance.RotateTowardDirection(transform.position, true);
            movement = Vector2.zero;
            npcState = DataEnum.NPCState.Talking;
        }
        else
        {
            ChangeDirection(true);
        }

    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            movement = Vector2.zero;
            npcState = DataEnum.NPCState.Talking;
        }
    }



    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player") && PlayerComponent.Instance.currentTalkingNpc)
        {
            rigbody.mass = 1;
            PlayerComponent.Instance.currentTalkingNpc = null;
            if (GameManager.Instance.btntalk)
                GameManager.Instance.btntalk.gameObject.SetActive(false);
            ChangeDirection();
        }
    }

    public void PlayWalkSfx()
    {

    }
}
