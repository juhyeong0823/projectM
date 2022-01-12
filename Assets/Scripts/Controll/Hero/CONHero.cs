using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum State
{
    IDLE,
    CHASE,
    ATTACK
}

public class CONHero : CONCharacter
{
    // 히어로 고유의 스킬 구현 등
    protected State curState;

    protected CONMonster target;
    protected float walkDir = 1f;
    protected SpriteRenderer sr;

    public float moveSpeed = 3f;

    public Sprite skillIcon;
    public int skillCost;

    public override void Awake()
    {
        base.Awake();

        sr = GetComponent<SpriteRenderer>();
    }

    public override void OnEnable()
    {
        base.OnEnable();

        bCanAttack = true;
        curState = State.IDLE;
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

    public override void Update()
    {
        base.Update();

        CheckState();
        CheckMonster();
    }

    private void CheckState()
    {
        switch (curState)
        {
            case State.IDLE:
                Idle();
                break;

            case State.CHASE:
                Chase();
                break;

            case State.ATTACK:
                Attack();
                break;
        }
    }

    protected void Idle()
    {
        Walk();
        CheckMonster();
    }

    protected void Chase()
    {
        ChaseMonster();
    }

    protected void Attack()
    {
        AttackMonster();
    }

    private void Walk()
    {
        myVelocity = new Vector3(walkDir * moveSpeed, 0f);

        Vector3 screenMax = GameSceneClass.gMGGame.mainCam.ViewportToWorldPoint(new Vector3(1f, 1f));
        Vector3 screenMin = GameSceneClass.gMGCastle.attackTrm.position;

        // 화면 밖을 넘어섰다면
        if (myTrm.position.x > screenMax.x)
        {
            myTrm.position = new Vector3(screenMax.x, myTrm.position.y, 0f);
            walkDir = -1f;

            sr.flipX = false;
        }
        else if (myTrm.position.x < screenMin.x)
        {
            myTrm.position = new Vector3(screenMin.x, myTrm.position.y, 0f);
            walkDir = 1f;

            sr.flipX = true;
        }
    }

    private void CheckMonster()
    {
        if (!bCanAttack) return;

        List<CONMonster> monsterList = GameSceneClass.gMGWave.monsterList;

        // 몬스터가 있다면
        if (monsterList.Count > 0)
        {
            target = UtilClass.GetNearbyEnemy(myTrm, monsterList);

            curState = State.CHASE;
        }
    }

    private void ChaseMonster()
    {
        Vector3 dir = target.myTrm.position - myTrm.position;

        myVelocity = dir.normalized * 5f;

        sr.flipX = dir.normalized.x > 0f;

        if (dir.sqrMagnitude < attackDist * attackDist)
        {
            myVelocity = Vector3.zero;
            curState = State.ATTACK;
        }

        if (target.isDie)
        {
            curState = State.IDLE;
        }
    }

    private void AttackMonster()
    {
        if (!bCanAttack) return;

        if (target.isDie)
        {
            curState = State.IDLE;
        }
        else
        {
            StartCoroutine(AttackTarget(target));
        }
    }

    private IEnumerator AttackTarget(CONMonster target)
    {
        bCanAttack = false;

        target.GetDamage(10);

        yield return new WaitForSeconds(attackCooltime);

        bCanAttack = true;
    }

    protected virtual void ActiveSkill()
    {
        // 스킬 구현하시면 됩니다.
    }
}
