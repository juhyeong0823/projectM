using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CONMonster : CONCharacter
{
    public float moveSpeed = 2f;

    public override void Awake()
    {
        base.Awake();
    }

    public override void OnEnable()
    {
        base.OnEnable();

        myVelocity = new Vector3(-1f * moveSpeed, 0f, 0f);
    }

    public override void OnDisable()
    {
        base.OnDisable();
    }

    protected override void cleanUpOnDisable()
    {

    }

    protected override void firstUpdate()
    {
        base.firstUpdate();
    }
}
