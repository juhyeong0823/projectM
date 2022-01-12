using System;
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

        attackCooltime = 1f;
    }

    public override void OnEnable()
    {
        base.OnEnable();

        hp = maxHp;
        bCanAttack = true;
    }

    public override void OnDisable()
    {
        base.OnDisable();
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
        GameSceneClass.gMGWave.monsterList.Remove(this);
        

        Vector3 pos = GameSceneClass.gMGGame.mainCam.WorldToScreenPoint(this.transform.position);
        Instantiate(Global.prefabsDic[ePrefabs.PlusButton], pos, Quaternion.identity, GameSceneClass.gUiRootGame.transform.root);
        SetActive(false);
    }

    protected override void cleanUpOnDisable()
    {

    }

    protected override void firstUpdate()
    {
        base.firstUpdate();
    }

    public override void Update()
    {
        base.Update();

        CheckCastle();
    }

    private void CheckCastle()
    {
        if (transform.position.x < GameSceneClass.gMGCastle.attackTrm.position.x)
        {
            myVelocity = Vector3.zero;

            AttackCastle();
        }
        else
        {
            myVelocity = new Vector3(-1f * moveSpeed, 0f, 0f);
        }
    }

    private void AttackCastle()
    {
        if (!bCanAttack) return;

        StartCoroutine(AttackTarget());
    }

    private IEnumerator AttackTarget()
    {
        bCanAttack = false;

        print("АјАн!");
        GameSceneClass.gMGCastle.GetDamage(10);

        yield return new WaitForSeconds(attackCooltime);

        bCanAttack = true;
    }
}
