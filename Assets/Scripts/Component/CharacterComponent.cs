using UnityEngine;

/// <summary>
/// Base component that manages all possible player, npc behaviour and movement
/// </summary>
[RequireComponent(typeof(Rigidbody2D))]
public class CharacterComponent : MonoBehaviour
{

    /// <summary>
    /// Player's speed
    /// </summary>
    [SerializeField]
    protected float movementSpeed;

    /// <summary>
    /// The Offset of the angle according to the sprite delivered for the rotation
    /// </summary>
    [SerializeField]
    protected float angleOffset = 90;

    /// <summary>
    /// 
    /// </summary>
    protected Vector2 movement;

    /// <summary>
    /// Player rigidbody2D refrence
    /// </summary>
    protected Rigidbody2D rigbody;

    /// <summary>
    /// Player animator refrence
    /// </summary>
    public Animator animator;

    /// <summary>
    /// Variable that indicates if the player is in motion or not
    /// </summary>
    protected bool isMoving;

    /// <summary>
    /// Player next position when moving
    /// </summary>
    protected Vector2 nextPos;

    /// <summary>
    /// Boolean the definie if the character can move or not
    /// </summary>
    public bool preventMove;

    protected virtual void Awake()
    {
        rigbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Start is called before the first frame update
    protected virtual void Start()
    {

    }

    // Update is called once per frame
    protected virtual void Update()
    {

        if (movement == Vector2.zero)
        {
            isMoving = false;
        }
        else
        {
            isMoving = true;
        }

        UpdatePlayerAnimation();



    }

    void FixedUpdate()
    {
        Movement();
    }

    /// <summary>
    /// Function to move the player according to the player's inputs
    /// </summary>
    public void Movement()
    {

        nextPos = rigbody.position + movement * movementSpeed * Time.fixedDeltaTime;

        rigbody.MovePosition(nextPos);
        FlipToDirection(nextPos);
    }

    /// <summary>
    /// Function to rotate the player to his next destination
    /// </summary>
    /// <param name="target">Player nex direction</param>
    public void FlipToDirection(Vector3 target, bool force = false)
    {

        if (movement != Vector2.zero || force)
        {
            //get the direction of the next position from current position
            Vector3 dir = target - transform.position;
            if (dir.x < 0)
                transform.localScale = new Vector3(-1, 1);

            if (dir.x >= 0)
                transform.localScale = new Vector3(1, 1);
        }
    }



    /// <summary>
    /// Function to switch between player animations
    /// </summary>
    public void UpdatePlayerAnimation()
    {
        if (!animator)
            return;

        animator.SetBool("isMoving", isMoving);
    }

}
