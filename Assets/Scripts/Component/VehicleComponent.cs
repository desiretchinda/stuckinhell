using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Component that manages all the behavior on an vehicle
/// </summary>
[RequireComponent(typeof(Rigidbody2D))]
public class VehicleComponent : MonoBehaviour
{
    /// <summary>
    /// This vehicle acceleration
    /// </summary>
    public float acceleration = 10;

    public Sprite spSide;
    public Sprite spUp;
    public Sprite spDown;
    public SpriteRenderer spRender;

    /// <summary>
    /// the rotation speed of this vehicle when crossing a junction
    /// </summary>
    [HideInInspector]
    public float rotationAcceleration = 20;

    /// <summary>
    /// This vehicle speed
    /// </summary>
    public Vector2 speed;

    /// <summary>
    /// current direction of this vehicle
    /// </summary>
    public Vector2 direction;

    /// <summary>
    /// Rigidbody2d refence on this vehicle
    /// </summary>
    private Rigidbody2D rigbody;

    /// <summary>
    /// 
    /// </summary>
    public bool availableForSpawn;

    /// <summary>
    /// The direction that this Vehicle can not take(exemple going back when going foward after crossing à junction)
    /// </summary>
    public DataEnum.PossibleDirection preventDirection;

    /// <summary>
    /// The last past crossroads of this vehicle
    /// </summary>
    private CrossroadComponent crossroadHit;

    /// <summary>
    /// Possible directions of a vehicle in an intersection
    /// </summary>
    public List<DataEnum.PossibleDirection> possibleDirection = new List<DataEnum.PossibleDirection>();

    /// <summary>
    /// The index of the next vehicle direction in the list of directions in a junction
    /// </summary>
    public int nextDirectionIndex;

    /// <summary>
    /// Current angle between vehicle and his next destination
    /// </summary>
    float angle;

    /// <summary>
    /// current vehicle's rotation
    /// </summary>
    Quaternion rotation;

    // Start is called before the first frame update
    void Awake()
    {
        rigbody = GetComponent<Rigidbody2D>();

        rigbody.isKinematic = false;
        rigbody.angularDrag = 0.0f;
        rigbody.gravityScale = 0.0f;
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void FixedUpdate()
    {
        speed = direction * acceleration * Time.fixedDeltaTime;

        if (direction.x < 0)
            transform.localScale = new Vector3(2, 2);

        if (direction.x >= 0)
            transform.localScale = new Vector3(-2, 2);
        rigbody.velocity = speed;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("VehicleDestroyer"))
        {
            availableForSpawn = true;
            gameObject.SetActive(false);
        }

        if (other.CompareTag("Crossroad"))
        {
            crossroadHit = other.gameObject.GetComponent<CrossroadComponent>();
            if (crossroadHit)
            {
                ChangeDirection();
            }

        }
    }

    /// <summary>
    /// Function to change the direction of a vehicle when it arrives at a junction
    /// </summary>
    private void ChangeDirection()
    {



        if (crossroadHit.possibleDirection == null)
            return;
        if (crossroadHit.possibleDirection.Count <= 0)
            return;

        possibleDirection = new List<DataEnum.PossibleDirection>();

        for (int i = 0, length = crossroadHit.possibleDirection.Count; i < length; i++)
        {
            if (crossroadHit.possibleDirection[i] != preventDirection)
            {
                possibleDirection.Add(crossroadHit.possibleDirection[i]);
            }
        }
        nextDirectionIndex = Random.Range(0, possibleDirection.Count);

        if (spRender)
            spRender.sprite = spSide;

        switch (possibleDirection[nextDirectionIndex])
        {
            case DataEnum.PossibleDirection.Up:
                direction = Vector3.up;
                preventDirection = DataEnum.PossibleDirection.Down;
                if (spRender)
                    spRender.sprite = spUp;
                break;
            case DataEnum.PossibleDirection.Down:
                direction = Vector3.down;
                preventDirection = DataEnum.PossibleDirection.Up;
                if (spRender)
                    spRender.sprite = spDown;

                break;
            case DataEnum.PossibleDirection.Right:
                direction = Vector3.right;
                preventDirection = DataEnum.PossibleDirection.Left;
                break;
            case DataEnum.PossibleDirection.Left:
                direction = Vector3.left;
                preventDirection = DataEnum.PossibleDirection.Right;
                break;
            default:
                break;
        }

    }
}
