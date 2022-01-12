using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CONGagePlusButton : CONEntity
{
    public override void Start()
    {
        this.GetComponent<Button>().onClick.AddListener(() =>
        {
            GameSceneClass.gMGGame.PlusCurSkillGage();
            this.SetActive(false);
        });
    }
}
