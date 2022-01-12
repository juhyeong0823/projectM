using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CONArchor : CONCharacter
{
    public Transform attackPos;

    public override void Awake()
    {
        base.Awake();

        attackCooltime = 1f;
    }

    public override void OnEnable()
    {
        base.OnEnable();

        bCanAttack = true;
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

        CheckMonster();
    }

    private void CheckMonster()
    {
        if (!bCanAttack) return;

        List<CONMonster> monsterList = GameSceneClass.gMGWave.monsterList;

        // 몬스터가 있다면
        if (monsterList.Count > 0)
        {
            CONMonster target = UtilClass.GetNearbyEnemy(myTrm, monsterList);
            StartCoroutine(AttackTarget(target));
        }
    }

    private IEnumerator AttackTarget(CONMonster target)
    {
        bCanAttack = false;

        CONArrow arrowCon = GameSceneClass.gMGPool.CreateObj(ePrefabs.Arrow, attackPos.position) as CONArrow;
        arrowCon.transform.localScale = new Vector3(1, 3, 1);
        arrowCon.Play(target.myTrm.position, () => 
        {
            target.GetDamage(10);
        });

        yield return new WaitForSeconds(attackCooltime);

        bCanAttack = true;
    }
}
