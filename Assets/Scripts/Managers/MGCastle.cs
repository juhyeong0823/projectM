using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MGCastle : MonoBehaviour
{
    public Transform attackTrm;
    public List<Transform> archerTrmList = new List<Transform>();

    private int maxHP;
    public int MaxHP => maxHP;

    private int curHP;
    public int CurHP => curHP;

    private event Action<int, int> onChangeHP;

    private void Awake()
    {
        GameSceneClass.gMGCastle = this;
    }

    public void GetDamage(int value)
    {
        curHP -= value;

        if (curHP <= 0)
        {
            // 게임오버 처리
            curHP = 0;
        }

        onChangeHP?.Invoke(maxHP, curHP);
    }
}
