using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CONSkill : CONEntity
{
    public Text costText;
    public Image skillIcon;
    public int cost;

    public void InitSkill(int cost, Sprite icon)
    {
        this.cost = cost;
        costText.text = cost.ToString();
        skillIcon.sprite = icon;
    }

    public void UseSkill()
    {
        if(GameSceneClass.gMGGame.CurSkillGage > cost)
        {
            GameSceneClass.gMGGame.CurSkillGage -= cost;
        }
    }
}
