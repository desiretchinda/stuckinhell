using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// The component that manages all possible player interaction and movement
/// </summary>
public class PlayerComponent : CharacterComponent
{
    public static PlayerComponent Instance;

    public NpcComponent currentTalkingNpc;

    RaycastHit hit;

    Ray ray;

    Transform objectHit;

    new void Awake()
    {
        Instance = this;
        base.Awake();
    }

    new void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    new void Update()
    {

        if (preventMove)
            return;

        movement = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        base.Update();
    }

}
