using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CONMonster : CONCharacter
{
    public float maxHp;
    protected float hp;

    public float moveSpeed = 2f;

    public override void Awake()
    {
        base.Awake();

    }

    public override void OnEnable()
    {
        base.OnEnable();
        GameSceneClass.gMGWave.monsterList.Add(this);

        hp = maxHp;
        myVelocity = new Vector3(-1f * moveSpeed, 0f, 0f);
    }

    public override void OnDisable()
    {
        base.OnDisable();
        GameSceneClass.gMGWave.monsterList.Remove(this);
    }

    public void GetDamage(int value)
    {
        hp -= value;

        if (hp <= 0)
        {
            OnDie();

            hp = 0;
        }
    }

    private void OnDie()
    {

        SetActive(false);
    }

    protected override void cleanUpOnDisable()
    {

    }

    protected override void firstUpdate()
    {
        base.firstUpdate();
    }
}
