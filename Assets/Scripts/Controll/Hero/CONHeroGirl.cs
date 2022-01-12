using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CONHeroGirl : CONHero
{
    public override void Awake()
    {
        base.Awake();

        CONSkill skill = GameObject.Instantiate(Global.prefabsDic[ePrefabs.Skill], GameSceneClass.gUIIngame.skillParent).GetComponent<CONSkill>();
        skill.InitSkill();
    }

    protected override void ActiveSkill()
    {
        
    }
}
