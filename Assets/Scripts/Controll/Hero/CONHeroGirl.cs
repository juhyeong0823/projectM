using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CONHeroGirl : CONHero
{
    public override void Awake()
    {
        base.Awake();

        CONSkill skill = GameObject.Instantiate(Global.prefabsDic[ePrefabs.Skill], GameSceneClass.gUIIngame.skillParent).GetComponent<CONSkill>();
        skill.InitSkill(skillCost,skillIcon);

        skill.skillBtn.onClick.AddListener(()=> 
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
        Debug.Log("스킬발동");
        StartCoroutine(StopAllMonster());
    }

    IEnumerator StopAllMonster()
    {
        List<CONMonster> monsters = GameSceneClass.gMGWave.monsterList;

        for (int i = 0; i < monsters.Count; i++) monsters[i].canAction = false;

        yield return new WaitForSeconds(3f);

        for (int i = 0; i < monsters.Count; i++) monsters[i].canAction = true;
    }

}
