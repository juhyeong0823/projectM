using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CONHeroMan : CONHero
{
    public override void Awake()
    {
        base.Awake();

        CONSkill skill = GameObject.Instantiate(Global.prefabsDic[ePrefabs.Skill], GameSceneClass.gUIIngame.skillParent).GetComponent<CONSkill>();
        skill.InitSkill(skillCost, skillIcon);

        skill.skillBtn.onClick.AddListener(() =>
        {
            if (skill.UseSkill())
                ActiveSkill();
            else
            {
                Debug.Log("돈이없어");
            }
        });
    }

    protected override void ActiveSkill()
    {
        StopCoroutine(PushAllMonster());
        StartCoroutine(PushAllMonster());
    }

    IEnumerator PushAllMonster()
    {
        List<CONMonster> monsters = GameSceneClass.gMGWave.monsterList;

        for (int i = 0; i < monsters.Count; i++)
        {
            monsters[i].Push();
            CONArrow arrowCon = GameSceneClass.gMGPool.CreateObj(ePrefabs.Arrow, this.transform.position) as CONArrow;
            arrowCon.transform.localScale = new Vector3(4, 12, 1);
            arrowCon.Play(target.myTrm.position, () =>
            {
                target.GetDamage(30);
            });
        }

        yield return new WaitForSeconds(2f);

        for (int i = 0; i < monsters.Count; i++)
        {
            monsters[i].Push(false);
        }
    }
}
