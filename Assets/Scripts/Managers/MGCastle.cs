using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MGCastle : MonoBehaviour
{
    public Transform attackTrm;
    public List<Transform> archerTrmList = new List<Transform>();

    private int castleHP;
    public int CastleHP => castleHP;

    private void Awake()
    {
        GameSceneClass.gMGCastle = this;
    }


}
