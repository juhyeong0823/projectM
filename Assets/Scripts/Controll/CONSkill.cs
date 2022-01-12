using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CONSkill : CONEntity
{
    public Text costText;
    public Image skillIcon;
    public int cost;

    public void SetText(int cost, Image icon)
    {
        this.cost = cost;
        costText.text = cost.ToString();
        skillIcon = icon;
    }

    public void UseSkill()
    {
        if(GameSceneClass.gMGGame.CurSkillGage > cost)
        {
            GameSceneClass.gMGGame.CurSkillGage -= cost;
        }
    }
}
